StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int case_num = int.Parse(rd.ReadLine());
int[] ints= new int[case_num];
int left_count = 1;
int right_count = 1;

for (int t = 0; t < case_num; t++)
{
    ints[t] = int.Parse(rd.ReadLine());
}

int a = ints[0];
int b = ints[case_num - 1];

for (int t = 1; t < case_num; t++)
{
    if(a < ints[t])
    {
        a = ints[t];
        left_count++;
    }

    if(b < ints[case_num -1 -t])
    {
        b = ints[case_num - 1 - t];
        right_count++;
    }
}

wr.WriteLine(left_count);
wr.WriteLine(right_count);
wr.Close();
