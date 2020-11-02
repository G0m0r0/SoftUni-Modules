using System;
using System.Collections.Generic;

namespace songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberSongs; i++)
            {
                string[] dataSong = Console.ReadLine().Split("_");

                Song song = new Song();

                song.TypeList = dataSong[0];
                song.Name = dataSong[1];
                song.Time = dataSong[2];

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if(typeList=="all")
            {
                foreach (Song item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach(Song item in songs)
                {
                    if(item.TypeList==typeList)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
        }
    }
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
