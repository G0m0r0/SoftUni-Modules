using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> songList = new Queue<string>(songs);

            while (songList.Count > 0)
            {
                string tokens = Console.ReadLine();
                if (tokens.StartsWith("Add"))
                {
                    string song = tokens.Remove(0, 4);
                    if (songList.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songList.Enqueue(song);
                    }
                }
                else if (tokens.StartsWith("Play"))
                {
                  //  if (songList.Count > 0) while have that condition
                        songList.Dequeue();
                }
                else if (tokens.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ",songList));
                }
            }
            if(songList.Count==0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
