namespace _19_1__1543
{
    class _1543
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string s = Console.ReadLine();
            int count = 0;
            for (int i = 0; i <= str.Length - s.Length; i++)
            {
                if (str[i..(i + s.Length)] == s)
                {
                    count++;
                    i += s.Length - 1;
                }
            }
            Console.WriteLine(count);
        }
    }
}
