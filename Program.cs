using System;
using System.Collections.Generic;
using Test.Classes;
namespace Test
{
    public interface IExecuteClass :IDisposable
    {
        void Execute();
    }

    public class CNode : IDisposable
    {
        public int value;
        public CNode next = null;

        public void Dispose() 
        {
            next = null;
        }
    }

    public class CircularLinkedList : IExecuteClass
    {
        private CNode start = null;

        public void insert(int data)
        {
            CNode node = new CNode() { value = data };
            CNode temp = start;

            //if the start node is null
            if (start == null)
            {
                start = node;
                node.next = node;
            }
            else
            {
                while (temp.next != start)
                {
                    temp = temp.next;
                }
                temp.next = node;
                node.next = start;
            }
        }

        public void display()
        {
            CNode temp = start;
            do
            {
                Console.Write($"{temp.value}->");
                temp = temp.next;
            } while (temp != start);
            Console.WriteLine();
        }

        public void insertInto(int data)
        {
            CNode node = new CNode() { value = data };
            CNode temp = start;

            while (temp.next != start && !(temp.value < data && temp.next.value > data))
            {
                temp = temp.next;
            }
            node.next = temp.next;
            temp.next = node;
            if (node.next == start) start = node;
        }

        public void Execute()
        {
            Console.WriteLine("Circular Linked List:");
            CircularLinkedList circular = new CircularLinkedList();

            circular.insert(1);
            circular.insert(2);
            circular.insert(4);
            circular.insert(5);
            circular.insert(7);
            circular.insertInto(3);
            circular.insertInto(0);
            circular.insertInto(6);
            circular.insertInto(-2);

            circular.display();
        }

        public void Dispose() 
        {
            CNode temp = start;
            while (temp != start)
            {
                temp.Dispose();
                temp = temp.next;
            }
            start = null;
        }
    }

    public class Ants : IExecuteClass
    {
        private void CellsComplete(ref int[] arr, int days)
        {
            int[] temp = (int[])arr.Clone();

            while (days > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int a, b;
                    if (i == 0) a = 0;
                    else a = arr[i - 1];

                    if (i == (arr.Length - 1)) b = 0;
                    else b = arr[i + 1];

                    temp[i] = a ^ b;
                }

                arr = (int[])temp.Clone();
                days--;
            }
        }

        public void Execute()
        {
            //sample input
            int[] arr = new int[] { 1, 1, 1, 0, 1, 1, 1, 1 };
            CellsComplete(ref arr, 2);

            Console.WriteLine("\nAnts:");
            Console.WriteLine("The array is ");

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        public void Dispose() 
        {
            
        }
    }


    public class Maze:IExecuteClass
    {
        public bool isPath(int i,int j,int[,] arr)
        {
            if (j >= 3 || i >= 3 || i<0 || j<0 || arr[i,j] == 0)
                return false;
            else
            {
                if (arr[i, j] == 9) return true;
                Console.WriteLine($"At arr[{i},{j}] = {arr[i,j]}");
                return isPath(i + 1, j, arr) || isPath(i, j + 1, arr);
            }
        }

        public void Execute() 
        {
            Console.WriteLine("\nMaze:");
            int[,] arr= new int[3,3]{ { 9, 0, 0 }, { 1, 1, 1 }, { 9, 1, 1 } };
            Console.WriteLine($"The Path exists:{isPath(0,0,arr)}");
            int[,] arr1 = new int[3, 3] { { 1, 0, 0 }, { 9, 1, 1 }, { 9, 1, 1 } };
            Console.WriteLine($"The Path exists:{isPath(0, 0, arr1)}");
            int[,] arr2 = new int[3, 3] { { 1, 0, 0 }, { 1, 9, 1 }, { 9, 1, 1 } };
            Console.WriteLine($"The Path exists:{isPath(0, 0, arr2)}");
        }

        public void Dispose() 
        {
            
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            List<IExecuteClass> executes = new List<IExecuteClass>
                                               {
                                                    new CircularLinkedList(),
                                                    new Ants(),
                                                    new Maze(),
                                                    new LinkedListClass(),
                                                    new FirstNonRepeatingCharacter(),
                                                    new FrequencySort(),
                                                    new LuckyNumber(),
                                                    new Google_SumOfTwoPair(),
                                                    new Google_FirstDuplicate(),
                                                    new ProductOfArrayExceptSelf()
                                               };

            for(int i = 0; i < executes.Count; i++)
            {
                executes[i].Execute();
                executes[i].Dispose();
                GC.Collect();
            }

        }
    }
}
