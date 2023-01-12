StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] bag_inform = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int case_num = bag_inform[0];
int weight = bag_inform[1];

int[,] value = new int[case_num + 1, weight +1];

for(int i = 1; i<= case_num; i++)
{
    int[] thing = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    int thing_weight = thing[0];
    int thing_value = thing[1];

    for(int j = 0; j < weight + 1; j ++)
    {
        if (j< thing_weight)
        {
            value[i, j] = value[i-1, j];
        }
        else
        {
            value[i, j] = Math.Max(value[i-1, j - thing_weight]+ thing_value, value[i-1, j]);
        }
    }
}
sw.WriteLine(value[case_num, weight]);
sw.Close();
