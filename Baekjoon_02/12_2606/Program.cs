StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int con_num = int.Parse(rd.ReadLine());
int case_num = int.Parse(rd.ReadLine());

Dictionary<int, List<int>> map = new();
for(int i = 0; i< case_num; i++)
{
    int[] input = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    if (!map.ContainsKey(input[0]))
    {
        map.Add(input[0], new List<int>());
        map[input[0]].Add(input[1]);
    }
    else
    {
        map[input[0]].Add(input[1]);
    }
    if (!map.ContainsKey(input[1]))
    {
        map.Add(input[1], new List<int>());
        map[input[1]].Add(input[0]);
    }
    else
    {
        map[input[1]].Add(input[0]);
    }
}

Queue<int> que = new();
bool[] visited = new bool[con_num + 1];
int count = 0;

que.Enqueue(1);

while(que.Count() >0)
{
    int a = que.Dequeue();
    visited[a] = true;
    count++;
    for(int i = 0; i < map[a].Count(); i++)
    {
        if (visited[map[a][i]] == false && !que.Contains(map[a][i]))
        {
            que.Enqueue(map[a][i]);
        }
    }

}

wr.WriteLine(count-1);
wr.Close();
