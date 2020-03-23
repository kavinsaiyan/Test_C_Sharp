using System;
namespace Test.Classes
{
    public class LuckyNumber : IExecuteClass
    {
        private int[][] arr = new int[10][];

        public void CountLuckyNumbers(int index) 
        {
            int count = 0,left= arr[index][0],right= arr[index][1];

            bool[] seive = new bool[right+ 1] ;

            for (int i = 2; i*i <= right; i++) 
            {
                if(!seive[i])
                    for (int j = i*i; j <= right; j+=(i*i)) 
                    {
                        seive[j] = true;
                        count++;
                    }
            }
            Console.WriteLine("No of iterations: "+count.ToString());
            count = 0;
            for(int i =left;i<=right;i++ )
                if (!seive[i])
                    count++;

            Console.WriteLine($"L:{ left} R:{ right } Count:{count}");
        }

        public void Dispose()
        {
            arr = null;
        }

        public void Execute()
        {
            Console.WriteLine($"\nLucky Number:");
            arr[0] = new int[] { 2, 4 };
            arr[1] = new int[] { 2, 5 };
            arr[2] = new int[] { 2, 6 };
            arr[3] = new int[] { 2, 7 };
            arr[4] = new int[] { 2, 8 };
            arr[5] = new int[] { 2, 9 };
            arr[6] = new int[] { 2, 10 };
            arr[7] = new int[] { 10, 20 };
            arr[8] = new int[] { 10, 100 };
            arr[9] = new int[] { 2, 1000 };
            for (int i = 0; i < arr.Length; i++)
                CountLuckyNumbers(i);

        }
    }
}
