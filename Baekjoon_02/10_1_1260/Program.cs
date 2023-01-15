using System.Reflection.PortableExecutable;

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
    if (!map.ContainsKey(input02[1]))
    {
        map.Add(input02[1], new List<int>());
        map[input02[1]].Add(input02[0]);
    }
    else
    {
        map[input02[1]].Add(input02[0]);
    }
}

Queue<int> visited = new();
Queue<int> need_visit = new();
Stack<int> need_visit2 = new();

need_visit.Enqueue(input01[2]);
need_visit2.Push(input01[2]);

while (need_visit2.Count > 0)
{
    int a = need_visit2.Pop();
    if (!visited.Contains(a))
    {
        visited.Enqueue(a); sw.Write(a + " ");
        if (map.ContainsKey(a))
        {
            map[a].Sort();
            for (int i = map[a].Count -1 ; i >= 0; i--)
            {
                need_visit2.Push(map[a][i]);
            }
        }

    }
}
sw.WriteLine();

visited.Clear();

while (need_visit.Count > 0)
{
    int a = need_visit.Dequeue();
    if (!visited.Contains(a))
    {
        visited.Enqueue(a); sw.Write(a + " ");
        if(map.ContainsKey(a))
        {
            map[a].Sort();
            for (int i = 0; i < map[a].Count; i++)
            {
                need_visit.Enqueue(map[a][i]);
            }
        }

    }
}
sw.Close();