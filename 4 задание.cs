using System;
using System.Collections.Generic;
namespace ConsoleApp28
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
    public class Deque<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;

        public void Search(T item)
        {
            int index = 0;
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    Console.WriteLine("Element found at position " + index);
                }

                current = current.Next;
                index++;
            }
        }

        public void AddToFront(T item)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }

        public void AddToBack(T item)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void Remove(T item)
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current == head)
                    {
                        head = current.Next;
                        if (head != null)
                        {
                            head.Previous = null;
                        }
                        else
                        {
                            tail = null;
                        }
                    }
                    else if (current == tail)
                    {
                        tail = current.Previous;
                        if (tail != null)
                        {
                            tail.Next = null;
                        }
                        else
                        {
                            head = null;
                        }
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    return;
                }

                current = current.Next;
            }
        }

        public void RemoveFromFront()
        {
            if (head != null)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null;
                }
                else
                {
                    tail = null;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void RemoveFromBack()
        {
            if (tail != null)
            {
                tail = tail.Previous;
                if (tail != null)
                {
                    tail.Next = null;
                }
                else
                {
                    head = null;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Print()
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            string c = Console.ReadLine();
            deque.AddToFront(a);
            deque.AddToBack(b);
            
            deque.AddToBack(4);
            deque.AddToFront(1);
            deque.AddToBack(2);
            deque.AddToFront(3);
            deque.AddToBack(4);

            deque.Print(); // Output: 3, 1, 2, 4

            deque.Search(2);
            
            deque.Remove(1);
            deque.RemoveFromFront();
            deque.RemoveFromBack();

            deque.Print(); // Output: 2

        }
    }
}











/*
 1. Мы определяем класс `Deque<T>`, который представляет двустороннюю очередь.
2. В этом классе у нас есть два приватных поля `head` и `tail`, которые представляют начало и конец очереди соответственно.
3. Метод `Search(T item)` выполняет поиск заданного элемента в очереди. Он перебирает все элементы, начиная с `head`, и выводит позицию каждого найденного элемента.
4. Метод `AddToFront(T item)` добавляет элемент в начало очереди. Он создает новую `DoublyNode<T>` с заданным элементом и делает следующее:
   - Если `head` равен `null`, то это значит, что очередь пуста. В этом случае новая нода становится и `head`, и `tail`.
   - В противном случае, новая нода становится новым `head`, а старый `head` становится следующим для нового `head`.
5. Метод `AddToBack(T item)` добавляет элемент в конец очереди. Он создает новую `DoublyNode<T>` с заданным элементом и делает следующее:
   - Если `head` равен `null`, то это значит, что очередь пуста. В этом случае новая нода становится и `head`, и `tail`.
   - В противном случае, новая нода становится новым `tail`, а старый `tail` становится предыдущим для нового `tail`.
6. Метод `Remove(T item)` удаляет заданный элемент из очереди. Он перебирает все элементы, начиная с `head`, и делает следующее:
   - Если текущий элемент равен заданному элементу:
     - Если текущий элемент является `head`, то мы обновляем `head` на следующий элемент и обрабатываем случаи, когда `head` становится `null` или новым `head`.
     - Если текущий элемент является `tail`, то мы обновляем `tail` на предыдущий элемент и обрабатываем случаи, когда `tail` становится `null` или новым `tail`.
     - В противном случае, мы обновляем ссылки на следующий и предыдущий элементы так, чтобы пропустить текущий элемент.
7. Метод `RemoveFromFront()` удаляет элемент из начала очереди. Он обновляет `head` на следующий элемент и обрабатывает случаи, когда `head` становится `null` или новым `head`.
8. Метод `RemoveFromBack()` удаляет элемент из конца очереди. Он обновляет `tail` на предыдущий элемент и обрабатывает случаи, когда `tail` становится `null` или новым `tail`.
9. Метод `Print()` выводит элементы очереди, начиная с `head`.
 */