using System;

namespace CodingAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var tracker = new CodeTracker();
            tracker.PrintMethodByAuthor("Niki");
        }
    }

    class Car
    {
        [Author("Niki")]
        public void Move()
        {

        }
        [Author("Dido")]
        public void Drive()
        {

        }
        [Author("Niki")]
        public void Speed()
        {

        }
    }
}
