class program
{
    static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    static int result = 0;
    static int[] input = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    static void Main()
    {
        pivo((int)Math.Pow(2, input[0]), 0, 0); ;
    }
    static void pivo(int n, int x, int y)
    {
        if (n == 2)
        {
            if (x == input[1] && y == input[2])
            {
                wr.Write(result);
                wr.Close();
                return;
            }
            result++;
            if (x == input[1] && y + 1 == input[2])
            {
                wr.Write(result);
                wr.Close();
                return;
            }
            result++;
            if (x + 1 == input[1] && y == input[2])
            {
                wr.Write(result);
                wr.Close();
                return;
            }
            result++;
            if (x + 1 == input[1] && y + 1 == input[2])
            {
                wr.Write(result);
                wr.Close();
                return;
            }
            result++;
        }
        else
        {
            pivo(n / 2, x, y);
            pivo(n / 2, x, y + n / 2);
            pivo(n / 2, x + n / 2, y);
            pivo(n / 2, x + n / 2, y + n / 2);
        }
    }
}