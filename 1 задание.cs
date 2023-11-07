using System;
using System.Collections.Generic;

namespace ConsoleApp25
{
    class Stack
    {
        private int[] data;
        private int top;

        public Stack()
        {
            data = new int[100];
            top = -1;
        }

        public void Push(int value)
        {
            if (top >= 99)
            {
                Console.WriteLine("Stack is full");
                return;
            }

            data[++top] = value;
            Console.WriteLine("ok");
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            int value = data[top--];
            Console.WriteLine(value);
        }

        public void Back()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            int value = data[top];
            Console.WriteLine(value);
        }

        public void Size()
        {
            Console.WriteLine(top + 1);
        }

        public void Clear()
        {
            top = -1;
            Console.WriteLine("ok");
        }

        private bool IsEmpty()
        {
            return top == -1;
        }
    }
    class Program
    {
       

        static void Main(string[] args)
        {


            Stack stack = new Stack();

            
           
            string[] c = new string[] { } ;
            string input;
            int count = 0;
            Console.WriteLine("Commands:");
            while ((input = Console.ReadLine()) != "exit")
            {
                Array.Resize(ref c, count+1);
                c[count] = input;
                
                count++;
            }
            static bool AreAllDigits(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            Console.WriteLine("Results:");
            
            foreach (string i in c)
            {
                string[] parts = i.Split(' ');

                switch (parts[0])
                {
                    case "push":
                        
                        if (AreAllDigits(parts[1]) )
                        {
                            int value = int.Parse(parts[1]);
                            stack.Push(value);
                        }
                        else
                        {
                            Console.WriteLine("Uncorrect symbol!");
                        }
                        break;
                    case "pop":
                        stack.Pop();
                        break;
                    case "back":
                        stack.Back();
                        break;
                    case "size":
                        stack.Size();
                        break;
                    case "clear":
                        stack.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }

          

        }
    }
}
