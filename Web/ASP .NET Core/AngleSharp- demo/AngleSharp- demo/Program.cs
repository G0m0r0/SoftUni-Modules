namespace AngleSharp__demo
{
    using System;
    using System.Threading.Tasks;
    using AngleSharp;
    using AngleSharp.Dom;

    class Program
    {
        static async Task Main()
        {
            var url = new Url("https://www.sciencedaily.com/releases/2020/11/201113124047.htm");
            var config = Configuration.Default.WithDefaultLoader();
            var doc = await BrowsingContext.New(config).OpenAsync(url);

            var elements = doc.QuerySelectorAll(".hyphenate > div > p");

            var headline = doc.QuerySelectorAll(".headline")[0];
            //title
            //story

            Console.WriteLine(headline.TextContent);

            foreach (var item in elements)
            {
                Console.WriteLine(item.TextContent);
                //Console.WriteLine("Innet htnl___________"+item.InnerHtml);
                //Console.WriteLine("Outer html___________"+item.OuterHtml);
                //Console.WriteLine("to html______________"+item.ToHtml());
            }

        }
    }
}
