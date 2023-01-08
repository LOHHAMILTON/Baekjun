StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int[] case_num = Array.ConvertAll<string, int>(rd.ReadLine().Split(' '), int.Parse);
int[] row = new int[case_num[0]];
int[] column = new int[case_num[1]];
for (int t = 0; t <  row.Length; t++)
{
    string input = rd.ReadLine();
    for(int j = 0; j < column.Length; j++)
    {
        if (input[j] == 'X')
        {
            row[t] = 1;
            column[j] = 1;
        }
    }
}
int a = row.Count(x => x == 0);
int b = column.Count(x => x == 0);
if(a > b)
{
    wr.WriteLine(a);
}
else
{
    wr.WriteLine(b);
}
wr.Close();