using System.Runtime.CompilerServices;

class program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int case_num = int.Parse(sr.ReadLine());
        List<brick> input = new();
        List<(int, int)> output = new();
        int[] soon = new int[case_num];
        for (int i = 0; i < case_num; i++)
        {
            int[] brick_inform = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            input.Add(new brick(brick_inform[0], brick_inform[1], brick_inform[2]));
            soon[i] = brick_inform[0];
        }

        input = input.OrderBy(x => x.size).ToList();

         List<stacking> ints = new();
        ints.Add(new stacking(0, 0));

        int[] result = new int[case_num];
        
        for (int i = 0; i < case_num; i++)
        {
            result[i] = input[i].height;
            ints.Add(new stacking(i+1, input[i].size));
            for (int j = 0; j < i; j++)
            {
                if (input[i].weight > input[j].weight && result[i] < result[j] + input[i].height)
                {
                    result[i] = result[j] + input[i].height;
                    ints[i + 1].index = j+1;
                }

            }
        }
        int count = 1;
        Stack<int> stack = new Stack<int>();
        find(Array.IndexOf(result, result.Max())+1);
        int a = stack.Count;
        for(int i =0; i < a; i ++)
        {
            sw.WriteLine(stack.Pop());
        }
        sw.Close();

        void find(int a)
        {
            while(a != ints[a].index)
            {
                count++;
                stack.Push(Array.IndexOf(soon, ints[a].size)+1);
                a = ints[a].index;
            }
            stack.Push(Array.IndexOf(soon, ints[a].size) + 1);
            stack.Push(count);
        }
    }

}


class brick
{
    public int size;
    public int height;
    public int weight;
    public brick(int size, int height, int weight)
    {
        this.size = size;
        this.height = height;
        this.weight = weight;
    }
}

class stacking
{
    public int index;
    public int size;

    public stacking(int index, int size)
    {
        this.index = index;
        this.size = size;
    }
}
