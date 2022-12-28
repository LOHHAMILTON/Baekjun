class program
{
    static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    static void Main()
    {
        int num = int.Parse(rd.ReadLine());

        wr.WriteLine(pivo(num));
        wr.Flush();
        rd.Close();
        wr.Close();
    }
    static int pivo(int num)
    {
        int first = 0;
        int second = 1;
        for (int i = 1; i < num; i++)
        {
            int sum = first+ second;
            first = second; second = sum;
        }
        return second;
    }
}