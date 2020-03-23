using System;
using System.Collections.Generic;


namespace Test.Classes
{
    public class ProductOfArrayExceptSelf : IExecuteClass
    {
        int[] arr;

        private void productOfArray() 
        {
            Console.WriteLine($"Input Array:{string.Join(',',arr)}");
            int length = arr.Length;
            int[] arrleft = new int[length], arrright = new int[length],outarr = new int[length];

            arrleft[0] = 1;
            arrright[length - 1] = 1;

            for (int i = 1; i < length; i++)
                arrleft[i] = arrleft[i - 1] * arr[i - 1];

            for (int i = length-2; i >= 0; i--)
                arrright[i] = arrright[i + 1] * arr[i + 1];

            for (int i = 0; i < length; i++)
                outarr[i] = arrleft[i] * arrright[i];

            Console.WriteLine($"Output Array:{string.Join(',', outarr)}\n");
        }

        public void Dispose()
        {
            arr = null;
        }

        public void Execute()
        {
            Console.WriteLine("\nProduct of array except self:");
            arr = new[] { 1,2,3,4 };
            productOfArray();

            arr = new[] { 5,6,7,8 };
            productOfArray();
        }
    }
}
