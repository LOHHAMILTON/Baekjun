public class Program
{
    struct Problem
    {
        public Problem(int dl, int cr)
        {
            deadline = dl;
            reward = cr;
        }
        public int deadline;
        public int reward;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Problem[] problems = new Problem[n];
        for (int i = 0; i < n; i++)
        {
            string[] problem = Console.ReadLine().Split(' ');
            problems[i] = new Problem(int.Parse(problem[0]), int.Parse(problem[1]));
        }
        problems = problems.OrderByDescending(p => p.deadline).ToArray();
        int idx = 0, answer = 0;
        PriorityQueue<int, int> pq = new();
        for (int i = n; i >= 1; i--)
        {
            while (idx < n && problems[idx].deadline >= i)
            {
                pq.Enqueue(problems[idx].reward, -problems[idx++].reward);
            }
            if (pq.Count > 0)
                answer += pq.Dequeue();
        }
        Console.Write(answer);
    }
}