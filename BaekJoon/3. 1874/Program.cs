using System;
using System.Windows.Markup;

namespace ConsoleApp1
{
    public class 블랙잭
    {
        static void Main(string[] args)
        {
            Stack<int> values = new();
            var times = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 0;

            for(int i = 0; i < times; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if(b < input)
                {
                    for (int j = b; j < input; j++)
                    {
                        values.Push(b + 1);
                        Console.WriteLine("+");
                        b++; 
                    }
                }

                if(b > input)
                {
                    values.Pop();
                    Console.WriteLine("-");
                }
            }

            Console.ReadLine();
        }
    }
}