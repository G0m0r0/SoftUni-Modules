using System;
using System.Collections;
using System.Collections.Generic;

namespace Inerators_and_comparators
{
    //interfaces
    public interface IMovable
    {
        //by default they are public
        void Move(int distance);
    }


    //public class Vechicle:Object  we dont see that : object
    public class Vechicle : Object,IMovable
    {
        //public Vechicle vechile;

        public void Move(int distance)
        {
            Console.WriteLine($"Moved with {distance}");
        }
    }       
    public  class Car : Vechicle
    {
        public void ChangeTransmision()
        {
            Console.WriteLine("Changed");
        }
    }
    //we aways takes two methods with IEnumnerable
    public class Motorbike : Vechicle, IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class MyEnumerator : IEnumerator<int>
    {
        public int Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            IMovable vechile = new Motorbike();
            vechile.Move(123);

            IEnumerable<int> list = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerator<int> enumerator = list.GetEnumerator();

            //foreach
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
