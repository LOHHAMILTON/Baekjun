StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
string[] input = rd.ReadLine().Split(' ');
int island_num = int.Parse(input[0]);
int case_num = int.Parse(input[1]);
island[] graph;
graph = new island[island_num + 1];

for (int i = 0; i <= island_num; i++)
{
    graph[i] = new();
}

for (int i = 0; i < case_num; i++)
{
    string[] input_01 = rd.ReadLine().Split(' ');
    int a = int.Parse(input_01[0]);
    int b = int.Parse(input_01[1]);
    int c = int.Parse(input_01[2]);    
    graph[a].bridge.Add((b, c));
    graph[b].bridge.Add((a, c));
}

string[] input_02 = rd.ReadLine().Split(' ');
int start = int.Parse(input_02[0]);
int end = int.Parse(input_02[1]);

int max_weight = graph[start].bridge.Max(x => x.Item2);
int min_weight = 1;

while (max_weight >= min_weight)
{
   
    int mid = (max_weight + min_weight) / 2;
    if (BFS(mid))
    {
        min_weight = mid + 1;
    }
    else
    {
        max_weight = mid - 1;
    }
}
wr.WriteLine(max_weight);
wr.Close();

bool BFS(int mid)
{
    Queue<int> need_visit = new Queue<int>();
    need_visit.Enqueue(start);
    bool[] visited = new bool[island_num+1];
    visited[start] = true;

    while (need_visit.Count > 0)
    {
        int curFactory = need_visit.Dequeue();

        if (curFactory == end)
        {
            return true;
        }
        for (int i = 0; i < graph[curFactory].bridge.Count; i++)
        {
            int next = graph[curFactory].bridge[i].Item1;
            int nextCost = graph[curFactory].bridge[i].Item2;

            if (!visited[next] && mid <= nextCost)
            {
                visited[next] = true;
                need_visit.Enqueue(next);
            }
        }
    }
    return false;
}

public class island
{
    public List<(int, int)> bridge = new();
}
