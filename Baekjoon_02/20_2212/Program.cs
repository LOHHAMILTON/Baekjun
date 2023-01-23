StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int sensor_num = int.Parse(rd.ReadLine());
int base_num = int.Parse(rd.ReadLine());

int[] input01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
int[] sensor_ps = input01.OrderBy(x => x).ToArray();

int max = sensor_ps[sensor_ps.Length - 1];
int min = 0;
int distance = 0;

while (true)
{
    bool[] cover_range = new bool[input01.Length];
    distance = 0;
    int mid = (max + min) / 2;
    int count_base = 0;
    for (int i = 0; i < sensor_num; i++)
    {
        if (!cover_range[i])
        {
            cover_range[i] = true;
            for (int j = i + 1; j < sensor_num; j++)
            {
                if (j + 1 < sensor_ps.Length && sensor_ps[j] == sensor_ps[j + 1]) continue;
                if (sensor_ps[j] - sensor_ps[i] == mid)
                {
                    distance += sensor_ps[j] - sensor_ps[i];
                    count_base++;
                    cover_range[j] = true;
                    break;
                }
                else if (sensor_ps[j] - sensor_ps[i] > mid)
                {
                    distance += sensor_ps[j-1] - sensor_ps[i];
                    count_base++;
                    break;
                }
                if(count_base != base_num)
                {
                    cover_range[j] = true;
                }
            }
        }
    }
    if (base_num >= count_base)
    {
        max = mid - 1;
    }
    else if(base_num < count_base)
    {
        min++;
    }
    else if(base_num == count_base && cover_range[input01.Length-1])
    {
         break;
    }
    
}
wr.WriteLine(distance);
wr.Close();


