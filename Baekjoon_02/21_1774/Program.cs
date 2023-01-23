class Program
{
    static void Main()
    {
        StreamReader rd = new StreamReader(Console.OpenStandardInput());
        StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
        int[] input01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // 0 : 우주신 수 1 : 미리 연결된 통로 수
        int god_num = input01[0]; int turnel = input01[1];
        List<God> gods = new();
        Dictionary<int, Dictionary<int, decimal>> map = new();
        PriorityQueue<(int, int), decimal> edges = new(); //간선정보

        int[] root_find = new int[god_num + 1]; //유니온파인드에 쓸 루트 노드

        for (int i = 0; i < god_num; i++)
        {
            int[] input02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
            map.Add(i + 1, new Dictionary<int, decimal>());
            gods.Add(new God(i + 1, input02[0], input02[1]));
            root_find[i + 1] = i + 1;
            for (int j = 0; j < i; j++)
            {
                map[i + 1].Add(j + 1, Distance(gods[i], gods[j]));
                edges.Enqueue((i + 1, j + 1), Distance(gods[i], gods[j]));
            }
        }
        decimal distance = 0;

        for(int i = 0; i < turnel; i++)
        {
            int[] base_num = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
            Union(base_num[0], base_num[1]);
        }


        while (edges.Count > 0)
        {
            (int a, int b) = edges.Dequeue();
            if(!Isunion(a,b))
            {
                Union(a, b);
                if (map[a].ContainsKey(b))
                {
                    distance += map[a][b];
                }
                else
                {
                    distance += map[b][a];
                }
            }


        }


        wr.WriteLine("{0:F2}", distance);
        wr.Close();

        int Find_root(int a)
        {
            if (root_find[a] == a) return a;
            else a = root_find[a]; return Find_root(a);
            
        }
        void Union(int a, int b)
        {
            int find_a = Find_root(a); int find_b = Find_root(b);
                if(find_a < find_b) root_find[find_b] = find_a;
                else root_find[find_a] = find_b;
        }
        bool Isunion(int a, int b)
        {
            a = Find_root(a); b = Find_root(b);
            if (a == b) return true;
            else return false;
        }
        decimal Distance(God a, God b)
        {
            double c = Math.Abs(a.x - b.x);
            double d = Math.Abs(a.y - b.y);

            return (decimal)Math.Sqrt(c * c + d * d);
        }
    }
}


class God
{
    public int num = 0;
    public int x = 0;
    public int y = 0;

    public God(int num, int x, int y)
    {
        this.num = num;
        this.x = x;
        this.y = y;
    }
}