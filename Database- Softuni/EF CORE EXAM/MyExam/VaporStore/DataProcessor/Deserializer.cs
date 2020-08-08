namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.XmlHelper;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDTOs = JsonConvert.DeserializeObject<ImportGamesDTO[]>(jsonString);
            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();
            var sb = new StringBuilder();

            foreach (var dto in gamesDTOs)
            {
                Developer dev;
                Genre genre;
                int tagCounter = 0;

                if (!IsValid(dto) || dto.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                dev = developers.FirstOrDefault(d => d.Name == dto.Developer);
                genre = genres.FirstOrDefault(g => g.Name == dto.Genre);

                var game = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = dev == null ? new Developer() { Name = dto.Developer } : dev,
                    Genre = genre == null ? new Genre() { Name = dto.Genre } : genre
                };

                foreach (var tag in dto.Tags)
                {
                    GameTag searchTag;
                    if (tags.FirstOrDefault(t => t.Name == tag) == null)
                    {
                        var tagtoAdd = new Tag() { Name = tag };
                        game.GameTags.Add(new GameTag { Game = game, Tag = tagtoAdd });
                        tags.Add(tagtoAdd);
                    }
                    else
                    {
                        var foundTag = tags.FirstOrDefault(t => t.Name == tag);
                        game.GameTags.Add(new GameTag { Game = game, Tag = foundTag });
                    }
                    tagCounter++;
                }

                games.Add(game);
                if (dev == null)
                {
                    developers.Add(game.Developer);
                }
                if (genre == null)
                {
                    genres.Add(game.Genre);
                }

                sb.AppendLine(string.Format($"Added {game.Name} ({game.Genre.Name}) with {tagCounter} tags"));
            }

            context.Tags.AddRange(tags);
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var usersDtos = JsonConvert.DeserializeObject<ImportUsersDTO[]>(jsonString);
            var users = new List<User>();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    CardType type;
                    bool IsTypeValid = Enum.TryParse(cardDto.Type, out type);

                    if (!IsTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = type
                    };

                    user.Cards.Add(card);
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }


            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var purchaseDtos = XmlConverter.Deserializer<ImportPurchases>(xmlString, "Purchases");
            var purchases = new List<Purchase>();


            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime date;
                bool isdateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                PurchaseType type;
                bool IsTypeValid = Enum.TryParse(purchaseDto.Type, out type);

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.CardNumber);

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);

                var purchase = new Purchase
                {
                    Type = type,
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Date = date,
                    Game = game
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}