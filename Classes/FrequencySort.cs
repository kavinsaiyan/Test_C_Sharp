using System;
using System.Collections.Generic;

namespace Test.Classes
{
    public class FrequencySort : IExecuteClass
    {
        public Dictionary<int, int> dict = new Dictionary<int, int>();

        public void Sort(int[] arr)
        {
            int i = 0;
            for (i=0;i<arr.Length;i++)
            {
                if (dict.ContainsKey(arr[i]))
                    dict[arr[i]]++;
                else dict.Add(arr[i],1);
            }

            List<KeyValuePair<int, int>> keyValuePairs = new List<KeyValuePair<int, int>>(dict);
            keyValuePairs.Sort(delegate (KeyValuePair<int,int> e1,KeyValuePair<int,int> e2) 
                                {
                                    return e2.Value.CompareTo(e1.Value);
                                }  );

            int[] res = new int[arr.Length];i = 0;
            foreach (var e in keyValuePairs)
            {
                int temp = e.Value;
                while (temp-- > 0)
                    res[i++] = e.Key; 
            }
            keyValuePairs.Clear();
            keyValuePairs = null;

            for (i = 0; i < res.Length-1; i++)
                Console.Write($"{res[i]},");
            Console.Write(res[i]);
            Console.WriteLine();
        }

        public void Dispose()
        {
            dict.Clear();
        }

        public void Execute()
        {
            Console.WriteLine("\nFrequency Sort:");
            int[] arr = new[] { 1,2,3,4,4,3,3,3,2,2,1,1,1,1,1,5};
            Sort(arr);
        }
    }
}
