class program
{
    static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    static void Main()
    {
        int num = int.Parse(rd.ReadLine());
        int[] count = new int[10001];

        for (int i = 0; i < num; i++)
        {
            count[int.Parse(rd.ReadLine())]++;
        }

        for (int i = 1; i < count.Length; i++)
        {
            for ( int j = 0; j < count[i]; j++)
            {
                wr.WriteLine(i);
            }
        }
        wr.Flush();
        rd.Close();
        wr.Close();
    }
}