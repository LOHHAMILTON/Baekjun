using System.Text;
class main
{
    static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    static void Main()
    {
        StringBuilder std = new StringBuilder();
        int[,] moveset = new int[,] { { 1, -1, 0, 0 }, { 0, 0, 1, -1 } };
        int loop = int.Parse(rd.ReadLine());
        for (int l = 0; l < loop; l++)
        {
            int[] inp = Array.ConvertAll(rd.ReadLine().Split(), int.Parse);
            int x = inp[0];
            int y = inp[1];
            bool[,] arr = new bool[y, x];
            for (int i = 0; i < inp[2]; i++)
            {
                int[] data = Array.ConvertAll(rd.ReadLine().Split(), int.Parse);
                arr[data[1], data[0]] = true;
            }
            int count = 0;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (arr[i, j])
                    {
                        count++;
                        Queue<int[]> qu = new Queue<int[]>();
                        qu.Enqueue(new int[] { i, j });
                        arr[i, j] = false;
                        while (qu.Count > 0)
                        {
                            int[] data = qu.Dequeue();
                            for (int m = 0; m < 4; m++)
                            {
                                int curx = data[1] + moveset[0, m];
                                int cury = data[0] + moveset[1, m];
                                if (0 <= curx && curx < x && 0 <= cury && cury < y && arr[cury, curx])
                                {
                                    arr[cury, curx] = false;
                                    qu.Enqueue(new int[] { cury, curx });
                                }
                            }
                        }
                    }
                }
            }
            std.Append(count + "\n");
        }


        wr.Write(std);
        wr.Close();
    }
}