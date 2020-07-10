using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lessons
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //examples
            var list = new List<string> { "niki", "pesho", "ivan", "kiwi","nina","pesho2" };

            var list2 = list.Where(x => x.Length <= 4); //(lambda) method

            //with db IQuerable not IEnumerable

            //projection or we can make anonymous class
            List<myClass> myClass = new List<myClass>();
            var songs = myClass.Select(x => new NameProjection { Name = x.Name });


            //group by first letter
            var list3 = myClass
                .GroupBy(x => x.Name[0]) //Iquerable doesnt understand Name[0] so it should be substring(0,1)
                .Select(x => new
                {
                    FirstLetter = x.Key,
                    Count = x.Count(),
                });

            foreach (var group in list3)
            {
                Console.WriteLine(group.FirstLetter+" "+group.Count); //count sum min avg max over the group
            }

            //group by multiple criterias
            var list4 = myClass.GroupBy(x => new { x.Name, x.Name.Length }).Select(x=>new {Name=x.Key.Name,Length= x.Key.Length});

            //key have now two properties
            foreach (var group in list4)
            {
                Console.WriteLine(group.Name+" "+group.Length);
            }

            //expresssion func- IQueryable (similar to reflection)
            Expression<Func<myClass, bool>> predicate = x => x.Name.Length > 30;
            //predicate.Body
            //predicate.Type
        }
    }
    class myClass
    {
        public string Name { get; set; }
    }
    class NameProjection
    {
        public string Name { get; set; }
    }
}
