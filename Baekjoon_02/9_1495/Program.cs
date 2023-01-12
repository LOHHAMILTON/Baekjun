StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int[] input01 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int[] input02 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

bool[,] result = new bool[input01[0] + 1, input01[2] + 1];

for (int i = 0; i <= input01[2]; i++)
{
    result[0, i] = false;
    if (i == input01[1])
    {
        result[0, i] = true;
    }
}

for (int i = 1; i <= input01[0]; i++)
{
    for (int j = 0; j <= input01[2]; j++)
    {
        if (j + input02[i - 1] <= input01[2] && result[i - 1, j + input02[i - 1]] == true)
        {
                result[i, j] = true;
        }
        if (j - input02[i - 1] >= 0 && result[i - 1, j - input02[i - 1]] == true)
        {
                result[i, j] = true;

        }
    }
}
int max = -1;

for (int i = 0; i < input01[2] + 1; i++)
{
    if (result[input01[0], i] == true)
    {
        max = i;
    }
}
sw.WriteLine(max);
sw.Close();