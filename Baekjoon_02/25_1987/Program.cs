StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
int row_num = input[0];
int column_num = input[1];
List<string> map = new();
bool[] dic = new bool[26];


for (int i = 0; i < row_num; i++)
{
    map.Add(rd.ReadLine());
}
int count = 1;
int max = 0;

dic[map[0][0] - 65] = true;
search(0, 0, count);


wr.WriteLine(max);
wr.Close();
void search(int x, int y, int count)
{
    if(x < row_num  || y < column_num)
    {
        if (x + 1 < row_num && !dic[map[x + 1][y] - 65])
        {
            dic[map[x + 1][y] - 65] = true;
            search(x + 1, y, count + 1);
        }
        if (y + 1 < column_num && !dic[map[x][y + 1] - 65])
        {
            dic[map[x][y + 1] - 65] =  true;
            search(x, y + 1, count + 1);
        }
        if (y - 1 >= 0 && !dic[map[x][y - 1] - 65])
        {
            dic[map[x][y - 1] - 65] = true;
            search(x, y - 1, count + 1);
        }
        if (x - 1 >= 0 && !dic[map[x - 1][y] - 65])
        {
            dic[map[x - 1][y] - 65] = true;
            search(x - 1, y, count + 1);
        }
    }
    dic[map[x][y] - 65] = false;
    max = Math.Max(count, max);
}