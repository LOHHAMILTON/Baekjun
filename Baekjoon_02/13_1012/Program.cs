using System.Drawing;

StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
int test_case = int.Parse(rd.ReadLine());
for (int i = 0; i < test_case; i++)
{
    int[] field = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // 0 가로, 1세로. 2배추갯수
    int[,] list = new int[field[1], field[0]];
    for (int j = 0; j < field[2]; j++)
    {
        int[] cabbage = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
        list[cabbage[1], cabbage[0]] = 1;
    }
    int count = 0;
    bool[,] visited = new bool[field[1], field[0]];

    for (int j = 0; j < field[1]; j++)
    {
        for (int k = 0; k < field[0]; k++)
        {
            if (list[j, k] == 1 && !visited[j, k])
            {
                Queue<(int, int)> q = new Queue<(int, int)>();
                q.Enqueue((j,k));
                visited[j, k] = true;
                while (q.Count > 0)
                {
                    (int a, int b) = q.Dequeue();

                    if (a + 1 < field[1] && !visited[a + 1, b] && list[a + 1, b] == 1)
                    {
                        visited[a + 1, b] = true; q.Enqueue((a + 1, b));
                    }
                    if (a - 1 >= 0 && !visited[a - 1, b] && list[a - 1, b] == 1)
                    {
                        visited[a - 1, b] = true; q.Enqueue((a - 1, b));
                    }
                    if (b + 1 < field[0] && !visited[a, b +1] && list[a, b+ 1] == 1)
                    {
                        visited[a, b + 1] = true; q.Enqueue((a, b+1));
                    }
                    if (b-1 >= 0 && !visited[a, b - 1] && list[a, b - 1] == 1)
                    {
                        visited[a, b -1] = true; q.Enqueue((a, b-1));
                    }
                }
                count++;
            }
        }
    }
    wr.WriteLine(count);
}
wr.Close();

