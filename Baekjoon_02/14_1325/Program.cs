StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

string[] input_01 = rd.ReadLine().Split(' ');

int com_num = int.Parse(input_01[0]);
int case_num = int.Parse(input_01[1]);

List<List<int>> map = new();
for (int i = 0; i <= com_num; i++)
{
    map.Add(new List<int>());
}

for (int i = 0; i < case_num; i++)
{
    int[] input_02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    map[input_02[1]].Add(input_02[0]);
}

List<(int, int)> result = new();

for (int i = 1; i <= com_num; i++)
{
    int count = bfs(i);
    result.Add((i, count));
}
result = result.OrderByDescending(x => x.Item2).ThenBy(x => x.Item1).ToList();
int d = result.Count(x => x.Item2 == result.Max(x => x.Item2));

for (int i = 0; i < d; i++)
{
    wr.Write(result[i].Item1 + " ");
}
wr.Close();

int bfs(int a)
{
    Queue<int> q = new();
    bool[] visited = new bool[com_num+1];
    int count = 1;
    q.Enqueue(a);
    while (q.Count() > 0)
    {
        int b = q.Dequeue();
        visited[b] = true;
        for (int j = 0; j < map[b].Count; j++)
        {
            if (!visited[map[b][j]])
            {
                q.Enqueue(map[b][j]);
                count++;
                visited[map[b][j]] = true;
            }
        }
    }
    return count;
}
