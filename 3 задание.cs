using System;

namespace ConsoleApp27
{
    class Program
    {
        static bool CheckBrackets(string text)
        {
            int count = 0;
            //int open = 0;
            //int close = 0;
            foreach (char ch in text)
            {
                if (ch == '(')
                {
                    //open++;
                    count++;
                }
                else if (ch == ')')
                {
                    //close++;
                    count--;
                    
                    if (count < 0)
                    {
                        return false;
                    }
                }
            }
            
           return count == 0;

            
        }

        static int CountExtraBrackets(string text)
        {
            //int count = 0;
            int open = 0;
            int close = 0;
            foreach (char ch in text)
            {
                if (ch == '(')
                {
                    open+=1;
                  //count++;
                }
                else if (ch == ')')
                {
                    close+=1;
                    //count--;
                }
            }
            if (open>close)
            {
                return (open - close);
            }
            else
            {
                return 0;
            }
            //return count > 0 ? count : 0;
        }
        static int FindFirstExtraBracket(string text)
        {
            int position = -1;
            int count = 0;
            int open = 0;
            int close = 0;
            //int im;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    count += 1;
                    open += 1;
                }
                else if (text[i] == ')')
                {
                    count -= 1;
                    close += 1;
                    if (close>open)
                    {
                        position = i;
                        //return position;
                       
                        break;
                    }
                }
            }
            return position;
            //return position;
        }

       
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();

            bool isCorrect = CheckBrackets(text);

            if (isCorrect)
            {
                Console.WriteLine("Скобки расставлены правильно.");
            }
            else
            {
                Console.WriteLine("Скобки расставлены неправильно.");

                int extraBrackets = CountExtraBrackets(text);
                if (extraBrackets > 0)
                {
                    Console.WriteLine("Лишних открывающих скобок: " + extraBrackets);
                }
                else
                {
                    int position = FindFirstExtraBracket(text);
                    Console.WriteLine("Лишняя закрывающая скобка на позиции " + position);
                }
            }

            //Console.ReadLine();
        }
    
    }
}
