namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using MusicHub.XmlHelper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var writers = JsonConvert.DeserializeObject<ImportWriterDTO[]>(jsonString);
            var writersList = new List<Writer>();

            foreach (var w in writers)
            {
                if (!IsValid(w))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer()
                {
                    Name = w.Name,
                    Pseudonym = w.Pseudonym,
                };

                writersList.Add(writer);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var jsonDTOs = JsonConvert.DeserializeObject<ImportProducersAlbumsDTO[]>(jsonString);

            var producers = new List<Producer>();
            foreach (var pa in jsonDTOs)
            {
                if(!IsValid(pa))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validAlbumsFlag = true;
                var albums = new List<Album>();
                foreach (var album in pa.Albums)
                {
                    if(!IsValid(album))
                    {
                        sb.AppendLine(ErrorMessage);
                        validAlbumsFlag = false;
                        continue;
                    }
                    DateTime realeaseDate;
                    bool isreleaseDateValid = DateTime.TryParseExact(album.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out realeaseDate);

                    if (!isreleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        validAlbumsFlag = false;
                        continue;
                    }

                    var newAlbum = new Album
                    {
                        Name = album.Name,
                        ReleaseDate = realeaseDate,
                    };

                    albums.Add(newAlbum);
                }

                if(!validAlbumsFlag)
                {
                    continue;
                }

                var producer = new Producer
                {
                    Name = pa.Name,
                    Pseudonym = pa.Pseudonym,
                    PhoneNumber = pa.PhoneNumber,
                    Albums = albums,
                };

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count()));
                }else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name,producer.PhoneNumber, producer.Albums.Count()));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var songsDtos = XmlConverter.Deserializer<ImportSongDto>(xmlString,"Songs");

            var songs = new List<Song>();
            foreach (var song in songsDtos)
            {
                if(!IsValid(song))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime createdOn;
                bool isCreatedOnValid = DateTime.TryParseExact(song.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdOn);

                if(!isCreatedOnValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;
                bool isDurationValid = TimeSpan.TryParseExact(song.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out duration);

                if(!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums.Find(song.AlbumId);
                var writer = context.Writers.Find(song.WriterId);
                var songTitle = songs.Any(s => s.Name == song.Name);

                if (album == null || writer == null || songTitle)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                bool isValidGenre = Enum.TryParse(song.Genre, out genre);
                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newSong = new Song
                {
                    Name = song.Name,
                    Duration = duration,
                    CreatedOn = createdOn,
                    Genre = genre,
                    AlbumId = song.AlbumId,
                    WriterId = song.WriterId,
                    Price = song.Price
                };

                songs.Add(newSong);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, newSong.Name, newSong.Genre, newSong.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}