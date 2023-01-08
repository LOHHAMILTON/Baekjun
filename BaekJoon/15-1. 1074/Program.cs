namespace _15_1._1074
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split();
            int N = Convert.ToInt32(inputs[0]);
            int R = Convert.ToInt32(inputs[1]);
            int C = Convert.ToInt32(inputs[2]);

            int ans = 0;
            while (N > 0)
            {
                int q = 3;
                int s = 1 << N - 1;
                if (R < s && C < s)
                    q = 0;
                else if (R < s && C >= s)
                    q = 1;
                else if (R >= s && C < s)
                    q = 2;
                R %= s;
                C %= s;
                ans += s * s * q;
                --N;
            }
            Console.WriteLine(ans);

        }

    }

}