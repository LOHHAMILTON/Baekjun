StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(rd.ReadLine());
List<(int, int)> list = new();
int count = 0;
for(int i = 0; i < N; i++)
{
   list.Add((0, i));
   Dfs(1, 0, list);
}

wr.WriteLine(count);
wr.Close();

void Dfs(int n, int column, List<(int, int)> list)
{
    if(n == N)
    {
        count++;
        list.RemoveAt(n-1);
    }
    else
    {
        for (int i = 0; i < N; i++)
        {
            if (is_pos(list, i, n))
            {
                int a = n+1;
                Dfs(a, 0, list);
            } 
            if(i == N - 1)
            {
                list.RemoveAt(n-1);
            }
        }
    }
}

bool is_pos(List<(int, int)> list, int column, int n)
{
    for (int i = 0; i < n; i++)
    {
        if (list[i].Item2 == column || (n - list[i].Item1) == Math.Abs(list[i].Item2 - column))
        {
            return false;
        }
    }
    list.Add((n, column));
    return true;
}
