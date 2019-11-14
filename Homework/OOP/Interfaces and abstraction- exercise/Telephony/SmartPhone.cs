using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class SmartPhone
    {
        public SmartPhone(List<string> sites, List<string> numbers)
        {
            this.Sites = sites;
            this.Numbers = numbers;
        }
        private List<string> sites;

        public List<string> Sites
        {
            get { return sites; }
            private set
            {
                //foreach (var site in this.Sites)
                //{
                //    if(site.ToCharArray().Any(x => char.IsDigit(x)))
                //    {
                //        throw new Exception("Invalid URL!");
                //    }
                //}

                sites = value;
            }
        }

        private List<string> numbers;

        public List<string> Numbers
        {
            get { return numbers; }
            set
            {
                // foreach (var number in this.Numbers)
                // {
                //     if (!number.ToCharArray().Any(x => char.IsDigit(x)))
                //     {
                //         throw new Exception("Invalid number!");
                //     }
                // }

                numbers = value;
            }
        }


        public void BrowseAll()
        {
            foreach (var site in this.Sites)
            {
                if (site.ToCharArray().Any(x => char.IsDigit(x)))
                {
                    throw new Exception("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {site}!");
                }
            }

        }

        public void CallAll()
        {
            foreach (var number in this.Numbers)
            {
                if (!number.ToCharArray().Any(x => char.IsDigit(x)))
                {
                    throw new Exception("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {number}");
                }
            }

        }
    }
}
