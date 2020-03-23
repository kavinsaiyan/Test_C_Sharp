using System;
using System.Collections.Generic;

namespace Test.Classes
{
    public class FirstNonRepeatingCharacter : IExecuteClass
    {
        private Dictionary<char, int> dict = new Dictionary<char, int>();

        private void FindRequiredCharacter(string inputString)
        {
            char res = '_';
            for (int i = 0; i < inputString.Length; i++)
            {
                if (dict.ContainsKey(inputString[i]))
                    dict[inputString[i]]++;
                else dict.Add(inputString[i], 1);
            }

            for (int i = 0; i < inputString.Length; i++)
                if (dict[inputString[i]] == 1)
                {
                    res = inputString[i];
                    break;
                }

            Console.WriteLine($"The Character is :{res}");
            dict.Clear();
        }

        public void Dispose()
        {
            dict.Clear();
        }

        public void Execute()
        {
            string[] sampleInputs = new[] { "aaabcccdeeef","abcbad","abcabcabc"};
            //output should be "b" ,"c" and "_"
            Console.WriteLine("\nFirst Non Repeating Character:");
            for (int i = 0; i < 3; i++)
                FindRequiredCharacter(sampleInputs[i]);
        }
    }
}
