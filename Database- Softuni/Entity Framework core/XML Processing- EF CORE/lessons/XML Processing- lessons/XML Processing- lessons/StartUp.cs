using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_Processing__lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            //var xml = File.ReadAllLines("Planes.xml");
            //XDocument xDocument = new XDocument();

            //or

            XDocument xml = XDocument.Load(@"../../../Planes.xml");
            //
            //Console.WriteLine(xml.Declaration.Encoding);
            //Console.WriteLine(xml.Root.Elements().Count());


            XDocument xmlDocument = XDocument.Load(@"../../../bgwiki-20200701-abstract.xml");

            var articles = xmlDocument.Root.Elements()
                .Where(x => x.Element("title").Value
                .Contains("Николай"))
                .OrderBy(x => x.Element("title").Value)
                .Select(x => new
                {
                    Title = x.Element("title").Value,
                    Description = x.Element("abstract").Value,
                    Url = x.Element("Url").Value,
                }).ToList();

            foreach (var article in articles)
            {
                //Console.WriteLine(article.Title);
            }

            xmlDocument.Save("myNewXML.xml");

            //to manipulate directly xml

            foreach (var article in xmlDocument.Root.Elements())
            {
                article.SetElementValue("links", null);
                article.SetAttributeValue("lang", null);
                article.Add(new XElement("new", "myNewValue"));
            }


            //CLASS TO SERIALIZE OR DESERIALIZE MUST START WITH LOWER LETTER IF WE DONT HAVE ATTRIBUTE

            //deserialize files  //internal or private dont deserialize
            XmlSerializer xmlSer = new XmlSerializer(typeof(Plane[]),
                new XmlRootAttribute("Planes"));

            var planes=(Plane[])xmlSer.Deserialize
                (File.OpenRead("bgwiki-20200701-abstract.xml.gz"));

            //serialize
            List<Plane> pl = new List<Plane>()
            {
                new Plane{Year=2000,Make="BMW",Model="2RTX5",Color="Red"},
            };

            XmlSerializer xmlDeSer = new XmlSerializer(typeof(Plane));

            xmlDeSer.Serialize(File.OpenWrite("../../../myNewPlanes.xml"),pl);
        }
    }
}
