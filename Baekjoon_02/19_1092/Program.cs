StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int crain_num = int.Parse(rd.ReadLine());

int[] input01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
int[] crains = input01.OrderBy(x => x).ToArray();
int[] task_sum = new int[crain_num];

int thing_num = int.Parse(rd.ReadLine());
int[] input02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
int[] things = input02.OrderByDescending(x => x).ToArray();

if(things.Max() > crains.Max())
{
    wr.WriteLine(-1);
    wr.Close();
    return;
}

for(int i = 0; i < things.Length; i++)
{
    for(int j = 0; j < crain_num; j++)
    {
        if (crains[j] >= things[i])
        {
            int index = j;
            int min = task_sum[j];
            for(int k = j+1; k < crain_num; k++)
            {
                if (min > task_sum[k])
                {
                    index = k;
                    min = task_sum[k];
                }
            }
            task_sum[index]++;
            break;
        }
    }
}
wr.WriteLine(task_sum.Max());
wr.Close();