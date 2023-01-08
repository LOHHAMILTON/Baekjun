public static class PS
{
    private class Island
    {
        public List<(int island, int weightLimit)> neighbors = new();
    }

    private static int n;
    private static Island[] map;
    private static int maxC;
    private static int start, end;

    static PS()
    {
        string[] input;

        input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        map = new Island[n + 1];

        for (int i = 0; i <= n; i++)
        {
            map[i] = new();
        }

        int m = int.Parse(input[1]);
        int a, b, c;
        maxC = 0;

        for (int i = 0; i < m; i++)
        {
            input = Console.ReadLine().Split();
            a = int.Parse(input[0]);
            b = int.Parse(input[1]);
            c = int.Parse(input[2]);
            maxC = Math.Max(maxC, c);

            map[a].neighbors.Add((b, c));
            map[b].neighbors.Add((a, c));
        }

        input = Console.ReadLine().Split();
        start = int.Parse(input[0]);
        end = int.Parse(input[1]);
    }

    public static void Main()
    {
        int left = 1;
        int right = maxC;
        int mid;

        while (left <= right)
        {
            mid = (left + right) / 2;

            if (BFS(mid))
                left = mid + 1;
            else
                right = mid - 1;
        }

        Console.Write(right);
    }

    private static bool BFS(int weight)
    {
        Queue<int> queue = new();
        bool[] visited = new bool[n + 1];

        queue.Enqueue(start);
        visited[start] = true;

        int cur;

        while (queue.Count > 0)
        {
            cur = queue.Dequeue();

            if (cur == end)
                return true;

            foreach (var neighbor in map[cur].neighbors)
            {
                if (!visited[neighbor.island] && weight <= neighbor.weightLimit)
                {
                    queue.Enqueue(neighbor.island);
                    visited[neighbor.island] = true;
                }
            }
        }

        return false;
    }
}