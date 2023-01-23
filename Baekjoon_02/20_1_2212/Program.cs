StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int sensor_num = int.Parse(rd.ReadLine());
int base_num = int.Parse(rd.ReadLine());

int[] input01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
int[] sensor_ps = input01.OrderBy(x => x).ToArray();
if(sensor_num <= base_num)
{
    wr.WriteLine(0);
    wr.Close();
    return;
}

PriorityQueue<int, int> q = new();

for (int i = 0; i < sensor_num - 1; i++) q.Enqueue(i,(sensor_ps[i + 1] - sensor_ps[i])*(-1));
List<int> list = new();

for(int i = 0; i< base_num-1; i ++)
{
    list.Add(q.Dequeue());

}
list.Sort();
int distance = 0;

int k = 0;
int j = 0;

for (j = 0; j < base_num-1;)
{
    distance += sensor_ps[list[j]] - sensor_ps[k];
    k = list[j] + 1;
    j++;
}
distance += sensor_ps[sensor_num -1] - sensor_ps[k];

wr.WriteLine(distance);
wr.Close();


