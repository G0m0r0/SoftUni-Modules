using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {

            Datte today = new Datte();

            Console.WriteLine(today.Year);
            today.DayOfTheMonth = 25;
            today.Month = 2;
            today.Year = 2019;
            Console.WriteLine(today.Year);

            today.AddYear();
            Console.WriteLine(today.Year); //20

            //another object with the same class like template
            Datte yesterday = new Datte();
            yesterday.Year = 2019;
            yesterday.Month = 2;
            yesterday.DayOfTheMonth = 24;
           // yesterday.AddYear();
            Console.WriteLine(yesterday.Year);


            Datte anotherexample = today;
            yesterday.AddYear();
            yesterday.AddYear();
            yesterday.AddYear();
            yesterday.AddYear();
            yesterday.AddYear();
            yesterday.AddYear();

            
        }
    }
    class Datte
    {
        public int Year;
        public int Month;
        public int DayOfTheMonth;

        //default consturcotr with no paramethers int the ()
        public Datte()
        {
                
        }

        //that is for method overload
        //constructors have to have the same name as the class
        public Datte(DateTime copyFrom)
        {
            Year = copyFrom.Year;
            Month = copyFrom.Month;
           // DayOfTheMonth = copyFrom.TimeOfDay;
        }

        //method
        public void AddYear()
        {
            Year++;
        }
    }
}
