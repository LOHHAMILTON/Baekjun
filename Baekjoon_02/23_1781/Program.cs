StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int task_num = int.Parse(rd.ReadLine());

List<(int deadline, int cup_Num)> list = new();

for (int i = 0; i < task_num; i++)
{
    int[] input = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    list.Add((input[0], input[1]));
}

list = list.OrderBy(x => x.deadline).ThenByDescending(x=>x.cup_Num).ToList();

PriorityQueue<int, int> min_heap = new();

for (int i = 0; i < task_num; i++)
{
    (int a, int b) = list[i];
    min_heap.Enqueue(b, b);
    if(min_heap.Count > a)
    {
        min_heap.Dequeue();
    }

}

int result = 0;
while(min_heap.Count>0)
{
    result += min_heap.Dequeue();
}
wr.WriteLine(result);
wr.Close();