namespace BattleCards2.Services
{
    using BattleCards2.Data;
    using BattleCards2.ViewModels.Cards;
    using System.Collections.Generic;
    using System.Linq;

    public class CardService : ICardService
    {
        private readonly ApplicationDbContext db;

        public CardService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddCard(InputCardModel card,string userId)
        {            
            var newCard = new Card
            {
                Name = card.Name,
                Description = card.Description,
                Health = card.Health,
                Attack = card.Attack,
                ImageUrl = card.Image,
                Keyword = card.Keyword,
                CreatorId=userId,
            };

            db.Cards.Add(newCard);
            db.SaveChanges();

            return newCard.Id;
        }

        public void AddCardToCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId,
            });
            this.db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            var cards = this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Health = x.Health,
                Attack = x.Health,
                ImageUrl = x.ImageUrl,
                Keyword = x.Keyword,
            }).ToList();

            return cards;
        }

        public IEnumerable<CardViewModel> GetAllCardsInColletion(string userId)
        {
            var cards = this.db.UserCards.Where(x => x.UserId == userId).Select(x => new CardViewModel
            {
                Id=x.Card.Id,
                Name=x.Card.Name,
                Description=x.Card.Description,
                Attack=x.Card.Attack,
                Health=x.Card.Health,
                Keyword=x.Card.Keyword,
                ImageUrl=x.Card.ImageUrl,
            }).ToList();

            return cards;
        }

        public void RemoveFromCollection(int cardId,string userId)
        {
            var card = this.db.UserCards
                .Where(x => x.CardId == cardId&&x.UserId==userId)
                .FirstOrDefault();

            this.db.UserCards.Remove(card);
            db.SaveChanges();
        }

        public bool RemoveFromEntireCollection(int cardId, string userId)
        {            
            var card = this.db.Cards.Where(x => x.Id == cardId).FirstOrDefault();

            if (card.CreatorId != userId)
            {
                return false;
            }

            this.db.Cards.Remove(card);
            db.SaveChanges();

            return true;
        }
    }
}
