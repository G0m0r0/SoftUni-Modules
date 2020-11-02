using System;
using System.Collections.Generic;
using System.Linq;

namespace articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int numOfChanges = int.Parse(Console.ReadLine());
            Article article = new Article();

            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];

            for (int i = 0; i < numOfChanges; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                switch (command[0])
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAutor(command[1]);
                        break;
                    case "Rename":
                        article.ChangeTitle(command[1]);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
    class Article
    {
        public string Title {set;get;}
        public string Content { set; get; }
        public string Author { set; get; }
               
        public void Edit(string newContent)
        {
            Content = newContent;
        }
        public void ChangeAutor(string newAutor)
        {
            Author = newAutor;
        }
        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

}
