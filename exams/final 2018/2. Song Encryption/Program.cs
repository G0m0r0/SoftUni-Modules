using System;
using System.Text;

namespace _2.Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command=Console.ReadLine())!="end")
            {
                string[] token = command.Split(":");
                string artist = token[0];
                string song = token[1];

                if(!ValidateArtist(artist))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if(!ValidateSong(song))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int keyValue = artist.Length;
                string encryptedMessage= EncryptWords(command,keyValue);
                Console.WriteLine($"Successful encryption: {encryptedMessage}");
            }
        }

        private static string EncryptWords(string command,int key)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ' ' || command[i] == '\'')
                {
                    encryptedMessage.Append(command[i]);
                    //continue;
                }
                else if (command[i] == ':')
                {
                    encryptedMessage.Append('@');
                    //continue;
                }
                else if (char.IsLower(command[i]) && command[i] + key > 122)
                {
                    encryptedMessage.Append((char)(command[i] + key - 26));
                   // continue;
                }
                else if (char.IsUpper(command[i]) && command[i] + key > 90)
                {
                    encryptedMessage.Append((char)(command[i] + key - 26));
                    //continue;
                }
                else
                {
                    encryptedMessage.Append((char)(command[i] + key));
                }
            }
            return encryptedMessage.ToString();
        }

        private static bool ValidateSong(string song)
        {
            for (int i = 0; i < song.Length; i++)
            {
                if(song[i]<65||song[i]>90)
                {
                    if(song[i]!=' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool ValidateArtist(string artist)
        {
            if(artist[0]<65||artist[0]>90)
            {
                return false;
            }
            for (int i = 1; i < artist.Length; i++)
            {
               // if(artist[i]>=65&&artist[i]<=90)
               // {
               //     return false;
               // }
                if(artist[i]<97||artist[i]>122)
                {
                    if(artist[i] != '\'' && artist[i] != ' ' )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
