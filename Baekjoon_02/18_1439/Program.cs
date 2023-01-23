StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int num = int.Parse(rd.ReadLine());
int[] predict = new int[num];
int[] rank  = new int[num];
bool[] visited = new bool[num];
for(int i = 0; i< num; i++)
{
    predict[i] = int.Parse(rd.ReadLine());
    rank[i] = i + 1;
}
int count = 0;
for(int i = 0; i< num; i++)
{
    int min = 500000;
    int index = -1;
    for(int j = 0; j<num; j++)
    {
        if (!visited[j] && Math.Abs(predict[i] - rank[j]) < min)
        {
            min = Math.Abs(predict[i] - rank[j]); index = j;
            
            if(min == 0) break;
        }
    }
    count += min;
    visited[index] = true;
}



wr.WriteLine(count);
wr.Close();
