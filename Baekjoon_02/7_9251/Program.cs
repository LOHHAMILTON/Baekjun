StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
string input01 = sr.ReadLine();
string input02 = sr.ReadLine();
List<List<int>> result = new();
for (int i = 0; i <= input01.Length; i++)
{
    result.Add(new List<int>());
}

for (int i = 0; i <= input02.Length; i++)
{
    result[0].Add(0);
}

for (int i = 1; i <= input01.Length; i++)
{
    int max = 0;
    result[i].Add(0);
    for (int j = 1; j <= input02.Length; j++)
    {
        max = Math.Max(max, result[i - 1][j - 1]);

        if (input01[i - 1] == input02[j - 1])
        {
            result[i].Add(max + 1);
        }
        else
        {
            result[i].Add(result[i - 1][j]);
        }
    }
}
sw.WriteLine(result[input01.Length].Max());
sw.Close();