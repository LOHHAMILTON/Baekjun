StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int test_case = int.Parse(rd.ReadLine());


for (int i = 0; i < test_case; i++)
{
    int[] input_01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // 0 :컴퓨터 개수 1: 의존성개수 2: 해킹당한 컴퓨터 번호
    List<List<(int other_com, int time)>> map = new();
    int[] result = new int[input_01[0] + 1];

    for (int j = 0; j <= input_01[0]; j++)
    {
        map.Add(new List<(int other_com, int time)>());
        result[j] = int.MaxValue;
    }

    for (int j = 0; j < input_01[1]; j++)
    {
        int[] input_02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // input_02[1]이 감염되면 input_02[0]도 input_02[2]초 후에 감염
        map[input_02[1]].Add((input_02[0], input_02[2]));
    }

    PriorityQueue<(int,int), int> q = new();
    int count = 1;
    q.Enqueue((input_01[2],0), 0);
    result[input_01[2]] = 0;
    while(q.Count > 0)
    {
        (int a, int b) = q.Dequeue();
        for(int j = 0; j < map[a].Count; j++)
        {
            if(map[a][j].time + result[a] < result[map[a][j].other_com])
            {
                q.Enqueue((map[a][j].other_com, map[a][j].time + result[a]), map[a][j].time);
                result[map[a][j].other_com] = map[a][j].time + result[a];
            }
        }
    }
    wr.Write(result.Count(x => x != int.MaxValue) + " ");
    int max = 0;
    for(int j = 0; j < result.Length; j++)
    {
        if (result[j] != int.MaxValue)
        {
            max = Math.Max(max, result[j]);
        }
    }
    wr.WriteLine(max);
}
wr.Close();