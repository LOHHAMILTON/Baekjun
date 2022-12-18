using System;

namespace ConsoleApp1
{
    public class 블랙잭
    {
        static void Main(string[] args)
        {
            string[] inputs1 = Console.ReadLine().Split();
            int N = int.Parse(inputs1[0]);
            int M = int.Parse(inputs1[1]);
            int[] array = new int[N];
            string[] inputs2 = Console.ReadLine().Split();
            int max = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                array[i] = int.Parse(inputs2[i]);
            }
            int temp;
            for (int i = 0; i < N - 2; i++)
            {
                for (int j = i + 1; j < N - 1; j++)
                {
                    for (int k = j + 1; k < N; k++)
                    {
                        temp = array[i] + array[j] + array[k];
                        if (temp <= M)
                        {
                            max = Math.Max(max, temp);
                        }
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}