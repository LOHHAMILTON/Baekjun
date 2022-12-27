class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
    static void Main()
    {


        int num = int.Parse(rd.ReadLine());
        int[] ans = new int[num];

        for (int i = 0; i < num; i++)
        {
            ans[i] = int.Parse(rd.ReadLine());
        }
        Array.Sort(ans);

        for (int i = 0; i < num; i++)
        {
            Console.WriteLine(ans[i]);
        }

    }
}