using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Classes
{
    public class LNode :IDisposable
    {
        public object value;
        public LNode next = null;

        public void Dispose() { next = null; value = null; }
    }

    public class LinkedListClass :IExecuteClass
    {
        private LNode start = null;

        public void insert(object data)
        {
            LNode node = new LNode() { value = data };
            LNode temp = start;

            //if the start node is null
            if (start == null)
            {
                start = node;
                node.next = null;
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
                node.next = null;
            }
        }

        public void display()
        {
            LNode temp = start;
            do
            {
                Console.Write($"{temp.value}->");
                temp = temp.next;
            } while (temp != null);
            Console.WriteLine("\n");
        }


        //find the count 
        //1.using iteration
        public void IterativeCount() 
        {
            int count = 0;
            LNode temp = start;
            while (temp != null) 
            {
                count++;
                temp = temp.next;
            }
            Console.WriteLine($"Iterative Count is :{count}");
        }

        //find the count 
        //2.using recursion (using delegates is more compute intensive)
        public void RecursiveCount1()
        {
            Func<LNode, int> fun = null;
            fun = (LNode node) => 
                        {
                            if (node == null) return 0;
                            return 1+fun(node.next);
                        };
            Console.WriteLine($"Recursive Count1 is :{fun(start)}");
        }

        //find the count 
        //2.using recursion (using normal recursion is less compute intensive)
        public int RecursiveCount2(LNode node)
        {
            if (node == null) return 0;
            return 1 + RecursiveCount2(node.next);           
        }

        //find the middle node and it's position 
        //1.using two pointers
        public (int,LNode) TwoPointerCount() 
        {
            int count = 0;
            LNode slowPointer =start, fastPointer = start;
            while (fastPointer!=null && fastPointer.next!=null) 
            {
                fastPointer = fastPointer.next.next;
                slowPointer = slowPointer.next;
                count++;
            }

            return (count,slowPointer);
        }

        //find the nth node from last
        public LNode FindNthNodeFromLast(int n) 
        {
            LNode nthNode=start,temp = start;

            while (n>0 && temp!=null) 
            {
                n--;
                temp = temp.next;
            }

            while (temp != null) 
            {
                temp = temp.next;
                nthNode = nthNode.next;
            }

            return nthNode;
        }

        //deletes the linked list
        public void Dispose()
        {
            LNode temp = start;
            while (temp != null)
            {
                temp.Dispose();
                temp = temp.next;
            }
            start = null;
        }

        //find the frquency 
        //1.Iterative
        public void FindFrequencyIterative(object data) 
        {
            int count = 0;
            LNode temp = start;
            while (temp != null) 
            {
                if (data.Equals(temp.value))
                    count++;
                temp = temp.next;
            }
            Console.WriteLine($"Iterative approach : {count}");
        }

        //find the frquency 
        //2.Recursive
        public int FindFrequencyRecursive(LNode node,object data)
        {
            if (node == null) return 0;
            if (node.value.Equals(data)) return 1 + FindFrequencyRecursive(node.next,data);
            return FindFrequencyRecursive(node.next, data);
        }
        public void Execute()
        {
            LinkedListClass linkedList = new LinkedListClass();
            Console.WriteLine("\nThe Linked List contains :");
            linkedList.insert(1);
            linkedList.insert(2);
            linkedList.insert(3);
            linkedList.insert(4);
            linkedList.insert(5);
            linkedList.display();
            linkedList.IterativeCount();
            linkedList.RecursiveCount1();
            Console.WriteLine($"Recursive Count2 is :{RecursiveCount2(linkedList.start)}\n");
            var tuple = linkedList.TwoPointerCount();
            Console.WriteLine($"\nThe middle node value is {tuple.Item2.value} and is at index :{tuple.Item1}");

            Console.WriteLine($"\nThe 2rd node from last is {linkedList.FindNthNodeFromLast(2).value}\n");

            linkedList.insert(5);
            linkedList.insert(5);
            linkedList.display();
            Console.WriteLine("The frequency of 5 in the linked list is ");
            linkedList.FindFrequencyIterative(5);
            Console.WriteLine($"Recursive approach : {linkedList.FindFrequencyRecursive(linkedList.start,5)}\n");
        }
    }
}
