StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
while (true)
{
    int[] input01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    int node_num = input01[0];
    int edge_num = input01[1];
    if (node_num == 0) break;

    int[] input02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    int start_Node = input02[0];
    int end_Node = input02[1];

    Dictionary<int, List<(int other, int time)>> map = new();
    Dictionary<int, List<(int other, int time)>> map_rev = new();

    int[] result01 = new int[node_num];  //최단경로 길이 
    int[] result02 = new int[node_num];  //거의 최단경로 길이

    for (int i = 0; i < node_num; i++)
    {
        result01[i] = int.MaxValue;
        result02[i] = int.MaxValue;
    }
    for (int i = 0; i < edge_num; i++)
    {
        int[] input03 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
        if (!map.ContainsKey(input03[0]))
        {
            map.Add(input03[0], new List<(int other, int time)>());
            map[input03[0]].Add((input03[1], input03[2]));
        }
        else map[input03[0]].Add((input03[1], input03[2]));
        if (!map_rev.ContainsKey(input03[1]))
        {
            map_rev.Add(input03[1], new List<(int other, int time)>());
            map_rev[input03[1]].Add((input03[0], input03[2]));
        }
        else map_rev[input03[1]].Add((input03[0], input03[2]));
    }
    bool[,] shortest = new bool[node_num , node_num];
    Dijkstra(result01);
    Detele_short();
    Dijkstra(result02);

    if (result02[end_Node] != int.MaxValue) wr.WriteLine(result02[end_Node]);
    else wr.WriteLine(-1);

    void Dijkstra(int[] result)
    {
        PriorityQueue<(int, int), int> q = new PriorityQueue<(int, int), int>();
        q.Enqueue((start_Node, 0), 0);
        result[start_Node] = 0;
        while (q.Count > 0)
        {
            (int a, int b) = q.Dequeue();
            if (a != end_Node && map.ContainsKey(a) && result[a] >= b)
            {
                for (int j = 0; j < map[a].Count; j++)
                {
                    if (map[a][j].time + result[a] < result[map[a][j].other] && !shortest[a, map[a][j].other])
                    {
                        q.Enqueue((map[a][j].other, map[a][j].time + result[a]), map[a][j].time);
                        result[map[a][j].other] = map[a][j].time + result[a];
                    }
                }
            }
        }
    }

    void Detele_short()
    {
        bool[] visited = new bool[node_num];
        Queue<int> q01 = new();
        q01.Enqueue(end_Node);
        while (q01.Count > 0)
        {
            int a = q01.Dequeue();
            if (a == start_Node) continue;
            if (map_rev.ContainsKey(a) && !visited[a])
            {
                visited[a] = true;
                for (int j = 0; j < map_rev[a].Count; j++)
                {
                    if (result01[a] - map_rev[a][j].time == result01[map_rev[a][j].other])
                    {
                        shortest[map_rev[a][j].other, a] = true;
                        q01.Enqueue(map_rev[a][j].other);
                    }
                }
            }
        }
    }
}
wr.Close();
