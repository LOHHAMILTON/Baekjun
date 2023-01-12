StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] input01 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
Dictionary<int, List<int>> map = new();

for(int i = 0; i < input01[1]; i++)
{
    int[] input02 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    if (!map.ContainsKey(input02[0]))
    {
        map.Add(input02[0], new List<int>());
        map[input02[0]].Add(input02[1]);
    }
    else
    {
        map[input02[0]].Add(input02[1]);
    }
}

sw.WriteLine();
sw.Close();