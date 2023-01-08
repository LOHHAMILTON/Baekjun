StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int[] case_num = Array.ConvertAll<string, int>(rd.ReadLine().Split(' '), int.Parse);
int house_num = case_num[0];
int[] house_pos = new int[house_num];
int ap = case_num[1];

for(int i = 0; i < house_num; i++)
{
    house_pos[i] = int.Parse(rd.ReadLine());
}

Array.Sort(house_pos);

int max = house_pos[house_num - 1] - house_pos[0];
int min = house_pos[1] - house_pos[0];
int mid = 0;
int result = 0;

while(max >= min)
{
    int count = 1;
    int first = house_pos[0];
    mid = (max + min) / 2;

    for(int i = 1; i< house_pos.Length; i++)
    {
        if(house_pos[i] >= first + mid)
        {
            count++;
            first = house_pos[i];
        }
    }
    if(ap <= count)
    {
        min = mid + 1;
        result = mid;
    }
    else if(ap > count)
    {
        max = mid - 1;
    }
}
wr.WriteLine(max);
wr.Close();