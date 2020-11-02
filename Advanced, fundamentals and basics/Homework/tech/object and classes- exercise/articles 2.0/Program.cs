using System;
using System.Collections.Generic;
using System.Linq;

namespace articles
{
    class Program
    {
        static void Main(string[] args)
        {            
            int numOfChanges = int.Parse(Console.ReadLine());
            
            List<Article> articles = new List<Article>();
           
            for (int i = 0; i < numOfChanges; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Article article = new Article();

                article.Title = input[0];
                article.Content = input[1];
                article.Author = input[2];
      
                articles.Add(article);

                /*
                string title = splittedCommand[0];
                string content = splittedCommand[1];
                string author = splittedCommand[2];

                var article = new Article(title, content, author);
                */                
            }
            string orderBy = Console.ReadLine();
           
            switch (orderBy)
            {
                case "title":
                    articles = articles.OrderBy(x => x.Title).ToList();
                 
                    break;
                case "content":
                    articles = articles.OrderBy(x => x.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(x => x.Author).ToList();
                    break;
                default:
                    break;
            }
            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
    class Article
    {
        public string Title { set; get; }
        public string Content { set; get; }
        public string Author { set; get; }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

}
