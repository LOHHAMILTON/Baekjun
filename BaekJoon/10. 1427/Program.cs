using System.Text;

class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
    static void Main()
    {
        char max;
        char num;

        string input = rd.ReadLine();


        StringBuilder sb = new StringBuilder();
        sb.Append(input);

        for (int i = 0; i < input.Length; i++)
        {
            max = sb[i];
            for (int j = i; j < input.Length; j++)
            {
                num = sb[j];
                max = sb[i];
                if ((int)max < (int)num)
                {
                    sb[i] = num;
                    sb[j] = max;
                }
            }

        }

        wr.WriteLine(sb);
        wr.Close();
        rd.ReadLine();
    }

}