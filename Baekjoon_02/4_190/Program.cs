StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int input = int.Parse(sr.ReadLine());
int[] result = new int[input + 1];
for (int i = 1; i <= input; i++)
{
    if (i <= 2)
    {
        result[i] = i;
    }
    else
    {
        result[i] = (result[i - 1] + result[i - 2]) % 15746;
    }
}
sw.WriteLine(result[input]);
sw.Close();
