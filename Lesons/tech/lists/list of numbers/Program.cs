using System;
using System.Collections.Generic;

namespace list_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //template class!!!!!!!!!!!!

            //we can add size of list (123)
            //start capatacity is 8 after that 16 then 32
            //inumerable
            List<int> numbers = new List<int>(123);

            int[] array = new[] { 1, 2, 3 };
            List<int> nums = new List<int>(array);

            nums.Add(4);

            foreach (var item in nums)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();

            for (int i = 0; i <10 ; i++)
            {
                nums.Add(i);
            }

            //for lenght .count
            Console.WriteLine(nums.Count);

            //Remove
            Console.WriteLine("__________________________");
            Console.WriteLine(string.Join(" ",nums));

            nums.Remove(7);
            //removes only one element
            //remove num and output true or false
            //its not a problem if we dont add it somewhere

            Console.WriteLine(string.Join(" ",nums));

            //remove all
            nums.RemoveAll(x => x == 1);
            nums.RemoveAll(x =>x!= 3);
            //lamba or predicate removes from database
            //=> means that when x==1 we remove all elements equal to 1

            //remove at num at index
           // nums.RemoveAt(2);

            //insert at sertain possition index,num
            nums.Insert(2, 123);

            //search for element output true and false
            //we need the output value because it doesnt change the list
            nums.Contains(5);
            bool foundOrNot = nums.Contains(5); //true
            if(nums.Contains(123))
                Console.WriteLine("We have num 123");

            //take element from index
            Console.WriteLine(nums[1]); //3

            nums.Add(int.MaxValue);
            //sort
            nums.Sort();
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
