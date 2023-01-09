StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
int case_Num = int.Parse(sr.ReadLine());

if(case_Num == 1)
{
    int input = int.Parse(sr.ReadLine());
    sw.WriteLine(0);
}

else
{
    for (int i = 0; i < case_Num; i++)
    {

        int input = int.Parse(sr.ReadLine());
        queue.Enqueue(input, input);
    }
    int result = 0;
    while (queue.Count > 1)
    {
        int a = queue.Dequeue(); // 10 20 30
        int b = queue.Dequeue();
        result += a + b;
        if (queue.Count == 0)
        {
            break;
        }
        queue.Enqueue(a + b, a + b);
    }
    sw.WriteLine(result);
}
sw.Close();
