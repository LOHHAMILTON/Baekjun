StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
int start = input[0];
int last = input[1];
int[] result = new int[100001];
result[start] = 1;
Queue<int> queue = new Queue<int>();
queue.Enqueue(start);

while (result[last] == 0)
{
    int a = queue.Dequeue();

    if (a - 1 >= 0 && result[a - 1] == 0)
    {
        queue.Enqueue(a - 1); result[a - 1] = result[a] + 1;
    }
    if (a + 1 <= 100000 && result[a + 1] == 0)
    {
        queue.Enqueue(a + 1); result[a + 1] = result[a] + 1;
    }
    if (2 * a <= 100000 && result[2 * a] == 0)
    {
        queue.Enqueue(2 * a); result[2 * a] = result[a] + 1;
    }
}
wr.WriteLine(result[last] - 1);
wr.Close();