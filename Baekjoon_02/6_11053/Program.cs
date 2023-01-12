StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int[] result = new int[int.Parse(sr.ReadLine())];
int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
for(int i = 0; i < input.Length; i++)
{
    result[i] = 1;

    for (int j = 0; j < i; j++)
    {
        if (input[j] < input[i])
        {
            result[i] = Math.Max(result[i], result[j] + 1);
        }
    }
}

sw.WriteLine(result.Max());
sw.Close();
