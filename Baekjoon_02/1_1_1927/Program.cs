StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
PriorityQueue<int, int> queue= new PriorityQueue<int, int>();
int case_Num = int.Parse(sr.ReadLine());
for (int i = 0; i < case_Num; i++)
{
    int input = int.Parse(sr.ReadLine());
    if (input == 0)
    {
        if (queue.Count == 0) sw.WriteLine(0);
        else
        {
            int a = queue.Dequeue();
            sw.WriteLine(a);
        }
    }
    else
    {
        queue.Enqueue(input, input);
    }
}
sw.WriteLine();
sw.Close();