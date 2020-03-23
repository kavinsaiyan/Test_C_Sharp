using System;
using System.Collections.Generic;

namespace Test.Classes
{
    public class Google_SumOfTwoPair : IExecuteClass
    {
        private HashSet<int> hashset = new HashSet<int>();
        private int[] arr1;
        private int[] arr2;

        private void SumOfTwoPair(int value) 
        {
            Console.WriteLine($"input array1: {string.Join(',',arr1)}");
            Console.WriteLine($"input array2: {string.Join(',',arr2)}\nvalue is {value}");

            for (int i = 0; i < arr1.Length; i++)
                hashset.Add(value-arr1[i]);

            bool flag = false;
            for (int i = 0; i < arr2.Length; i++)
                if (hashset.Contains(arr2[i]))
                    flag=true;
            if (flag) Console.WriteLine("Pair is present.\n");
            else Console.WriteLine("Pair is not present.\n");
            hashset.Clear();
        }

        public void Dispose()
        {
            arr1 = null;
            arr2 = null;
            hashset.Clear();
            hashset = null;
        }

        public void Execute()
        {
            Console.WriteLine("\nGoogle Sum Of Two Pair:");
            arr1 = new int[] { 1,2,3,4,5};
            arr2 = new int[] { 3,4,5,2,1,3};
            SumOfTwoPair(8);
            SumOfTwoPair(18);

            arr1 = new int[] { 1,23,43,131,542,345,-435,123,616,711,5675,5897 };
            arr2 = new int[] { 345,2345,234,6245,42,52435,65,224,34652,455,63,34 };
            SumOfTwoPair(-370);
            SumOfTwoPair(370);
        }
    }

}
