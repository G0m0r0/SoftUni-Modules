namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ExportDtos;
    using MusicHub.XmlHelper;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context
                .Albums//.ToArray() //for judge
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(x=>x.Songs.Sum(y=>y.Price))
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(y => new
                    {
                        SongName = y.Name,
                        Price = y.Price.ToString("F2"),
                        Writer = y.Writer.Name
                    })
                            .OrderByDescending(y => y.SongName)
                            .ThenBy(y => y.Writer)
                            .ToArray(),
                    AlbumPrice = x.Songs.Sum(y => y.Price).ToString("F2"),
                }).ToArray();

            var result = JsonConvert.SerializeObject(albumsInfo, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs
                //.ToArray()  //for judge
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new ExportSongsAboveDurationDTO
                {
                    Name = x.Name,
                    WriterName = x.Writer.Name,
                    PerformerName = x.SongPerformers.FirstOrDefault().Performer.FirstName+' '+                                    x.SongPerformers.FirstOrDefault().Performer.LastName,
                    AlbumProducerName = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c"),
                }).OrderBy(x=>x.Name)
                .ThenBy(x=>x.WriterName)
                .ThenBy(x=>x.PerformerName)
                .ToArray();

            var result = XmlConverter.Serialize(songsAboveDuration, "Songs");

            return result;
        }
    }
}