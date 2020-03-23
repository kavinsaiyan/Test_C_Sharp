using System;
using System.Collections.Generic;
namespace Test.Classes
{
    public class Google_FirstDuplicate : IExecuteClass
    {
        int[] arr;
        HashSet<int> hashSet = new HashSet<int>();

        public void FirstDuplicate() 
        {
            Console.WriteLine($"The input array is : {string.Join(',',arr)}");

            for(int i = 0; i < arr.Length; i++)
            {
                if (hashSet.Contains(arr[i]))
                {
                    Console.WriteLine($"First Duplicate is {arr[i]}.\n");
                    hashSet.Clear();
                    return;
                }
                else hashSet.Add(arr[i]);
            }
            hashSet.Clear();
            Console.WriteLine("There are no duplicates.\n");
        }

        public void Dispose()
        {
            arr = null;
            hashSet = null;
        }

        public void Execute()
        {
            Console.WriteLine("\nGoogle first duplicate:");
            arr = new int[] { 1,2,2,3,3,4,3,4,5,5};
            FirstDuplicate();

            arr = new int[] { 1, 2, 3, 4, 5, 5 };
            FirstDuplicate();
        }
    }
}
