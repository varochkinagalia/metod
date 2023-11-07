using System;
using System.Collections.Generic;

namespace ConsoleApp26
{
    class Queue
    {
        private int[] data;
        private int front;
        private int rear;
        private int count;

        public Queue()
        {
            data = new int[100];
            front = 0;
            rear = -1;
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == data.Length;
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }

            rear = (rear + 1) % data.Length;
            data[rear] = value;
            count++;
            Console.WriteLine("ok");
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("error");
                return;
            }

            int value = data[front];
            front = (front + 1) % data.Length;
            count--;
            Console.WriteLine(value);
        }

        public void Front()
        {
            if (IsEmpty())
            {
                Console.WriteLine("error");
                return;
            }

            Console.WriteLine(data[front]);
        }

        public void Size()
        {
            Console.WriteLine(count);
        }

        public void Clear()
        {
            front = 0;
            rear = -1;
            count = 0;
            Console.WriteLine("ok");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
           
            string[] c = new string[] { };
            int count = 0;

            string command;
            Console.WriteLine("Commands:");
            while ((command = Console.ReadLine()) != "exit")
            {
                
                Array.Resize(ref c, count + 1);
                c[count] = command;
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
                        {
                            if (AreAllDigits(parts[1]))
                            {
                                int value = int.Parse(parts[1]);
                                queue.Push(value);
                            }
                            else
                            {
                                Console.WriteLine("Uncorrect symbol!");
                            }
                            break;
                        }
                    case "pop":
                        queue.Pop();
                        break;
                    case "front":
                        queue.Front();
                        break;
                    case "size":
                        queue.Size();
                        break;
                    case "clear":
                        queue.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }

            Console.WriteLine("Bye");
        }
            
        
    
    }
}
