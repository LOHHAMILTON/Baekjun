StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int[] indegree = new int[input[0] + 1];
List<List<int>> list = new List<List<int>>();
for (int i = 0; i <= input[0]; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < input[1]; i++)
{
    int[] input01 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    list[input01[0]].Add(input01[1]);
    indegree[input01[1]]++;
}

for (int i = 1; i <= input[0]; i++)
{
    if (indegree[i] == 0)
    {
        queue.Enqueue(i, i);
    }
}

List<int> result = new();


while(queue.Count > 0)
{
    int data = queue.Dequeue();
    result.Add(data);
    for(int i = 0; i< list[data].Count; i++)
    {
        indegree[list[data][i]]--;
        if (indegree[list[data][i]] == 0)
        {
            queue.Enqueue(list[data][i], list[data][i]);
        }
    }
}
for(int i = 0; i < result.Count; i++)
{
    sw.Write(result[i]);
    sw.Write(' ');
}
sw.WriteLine();
sw.Close();


