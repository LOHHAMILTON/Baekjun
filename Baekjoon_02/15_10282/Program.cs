StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int test_case = int.Parse(rd.ReadLine());
List<List<(int other_com, int time)>> map = new();

for (int i = 0; i < test_case; i++)
{
    int[] input_01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // 0 :컴퓨터 개수 1: 의존성개수 2: 해킹당한 컴퓨터 번호
    for(int  j = 0; j <= input_01[1]; j++)
    {
        map[j] = new List<int other_com, int time>();
    }
    for (int j = 0; j < input_01[1]; j++)
    {
        int[] input_02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // input_02[1]이 감염되면 input_02[0]도 input_02[2]초 후에 감염
        map[input_02[1]].Add((input_02[0], input_02[2]));
    }

}

wr.WriteLine();
wr.Close();