namespace AngleSharp__demo
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AngleSharp;
    using AngleSharp.Dom;
    using AngleSharp.Html.Dom;

    class Program
    {
        static async Task Main()
        {

            var config = Configuration.Default.WithDefaultLoader();

            var url2 = new Url("https://phys.org/news/2020-11-rare-species-small-cats-inadequately.html");
            var doc2 = await BrowsingContext.New(config).OpenAsync(url2);

            //get image
            var image = doc2.GetElementsByClassName("article-img")[0].GetElementsByTagName("img")[0].GetAttribute("src");

            //credit:
            var credit = doc2.GetElementsByClassName("article-img")[0].GetElementsByTagName("figcaption")[0].TextContent.Trim();

            //mainText
            var textParagraphs = doc2.GetElementsByClassName("article-main")[0].GetElementsByTagName("p");
            var sb = new StringBuilder();
            foreach (var paragraph in textParagraphs)
            {
                sb.AppendLine(paragraph.TextContent.Trim());
                sb.AppendLine();
            }

            sb.ToString().TrimEnd();

            //title
            var title2 = doc2.GetElementsByClassName("news-article")[0].GetElementsByTagName("h1")[0].TextContent;

            Console.WriteLine(title2);

            for (int i = 1; i < 1; i++)
            {
                var url = new Url("https://phys.org/biology-news/ecology/sort/date/all/page" + i + ".html");
                var doc = await BrowsingContext.New(config).OpenAsync(url);

                var elements = doc.GetElementsByClassName("sorted-article")
                .Select(x => new
                {
                    MainPhoto = x.GetElementsByClassName("sorted-article-figure")[0]
                                .GetElementsByTagName("img")[0]
                                .GetAttribute("data-src"),
                    MainPage = x.GetElementsByClassName("sorted-article-figure")[0]
                                .GetElementsByTagName("a")[0]
                                .GetAttribute("href"),
                    Tile = x.GetElementsByClassName("sorted-article-content")[0]
                                .GetElementsByTagName("a")[0]
                                .TextContent,
                    ShortIntro = x.GetElementsByClassName("sorted-article-content")[0]
                                .GetElementsByTagName("p")[0]
                                .TextContent
                                .Trim(),
                    Category = x.GetElementsByClassName("article__info")[0]
                                .GetElementsByTagName("p")[0]
                                .TextContent
                                .Trim(),
                    PostedOn = x.GetElementsByClassName("article__info")[0]
                                .GetElementsByTagName("p")[1]
                                .TextContent
                                .Trim(),
                }).ToArray();

                foreach (var item in elements)
                {
                    Console.WriteLine(item.MainPage);
                    Console.WriteLine(item.MainPhoto);
                    Console.WriteLine(item.Tile);
                    Console.WriteLine(item.ShortIntro);
                    Console.WriteLine(item.Category);
                    Console.WriteLine(item.PostedOn);
                    Console.WriteLine();
                    //get main photo
                    //Console.WriteLine(item.GetElementsByClassName("sorted-article-figure")[0].GetElementsByTagName("img")/[0].GetAttribute("data-src"));

                    //get more info page
                    // Console.WriteLine(item.GetElementsByClassName("sorted-article-figure")[0].GetElementsByTagName("a")/[0].GetAttribute("href"));

                    //get title
                    // Console.WriteLine(item.GetElementsByClassName("sorted-article-content")[0].GetElementsByTagName("a")/[0].TextContent);

                    //get short intro
                    //Console.WriteLine(item.GetElementsByClassName("sorted-article-content")[0].GetElementsByTagName("p")/[0].TextContent.Trim());

                    //get category
                    //Console.WriteLine(item.GetElementsByClassName("article__info")[0].GetElementsByTagName("p")/[0].TextContent.Trim());

                    //get postedOn
                    //Console.WriteLine(item.GetElementsByClassName("article__info")[0].GetElementsByTagName("p")/[1].TextContent.Trim());

                    //Console.WriteLine(item.TextContent);
                    //Console.WriteLine("Innet htnl___________"+item.InnerHtml);
                    //Console.WriteLine("Outer html___________"+item.OuterHtml);
                    //Console.WriteLine("to html______________"+item.ToHtml());
                }
            }
        }
    }
}
