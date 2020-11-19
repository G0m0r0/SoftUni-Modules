using System;
using System.Configuration;
using System.Threading.Tasks;
using AngleSharp;

namespace AngleSharp
{
    class Program
    {
        static async Task Main()
        {
            //Use the default configuration for AngleSharp
            var config = Configuration.Default;

            //Create a new context for evaluating webpages with the given config
            var context = BrowsingContext.New(config);

            //Source to be parsed
            var source = "<h1>Some example source</h1><p>This is a paragraph element";

            //Create a virtual request to specify the document to load (here from our fixed string)
            var document = await context.OpenAsync(req => req.Content(source));

            //Do something with document like the following
            Console.WriteLine("Serializing the (original) document:");
            Console.WriteLine(document.DocumentElement.OuterHtml);

            var p = document.CreateElement("p");
            p.TextContent = "This is another paragraph.";

            Console.WriteLine("Inserting another element in the body ...");
            document.Body.AppendChild(p);

            Console.WriteLine("Serializing the document again:");
            Console.WriteLine(document.DocumentElement.OuterHtml);
        }
    }
}
