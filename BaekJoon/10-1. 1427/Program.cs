using System.Text;

class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
    static void Main()
    {
        string input = rd.ReadLine();
        char[] a = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        StringBuilder sb = new StringBuilder();

        for (int i = 9; i >= 0; i--)
        {
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == a[i])
                {
                    wr.Write(a[i]);
                }
            }
        }
        wr.Close();

    }

}