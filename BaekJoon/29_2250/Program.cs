using System.Globalization;
using System.Text;

StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int case_num = int.Parse(rd.ReadLine());

List<(int value, int row)> column = new();
column.Add((0, 0));

Dictionary<int, (int left, int right)> map = new();

for (int i = 0; i < case_num; i++)
{
    int[] input_01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    map.Add(input_01[0], (input_01[1], input_01[2]));
}

int root = 0;
for (int i = 1; i <= case_num; i++)
{
    for (int j = 1; j <= case_num; j++)
    {
        if (map[j].left == i || map[j].right == i)
        {
            break;
        }
        if (j == case_num)
        {
            root = i;
        }
    }
}

Inorder(root, 1);
int a = 0;
int b = 0;
for (int i = 1; i <= column.Max(x => x.row); i++)
{
    List<int> result = new();
    for (int j = 1; j <= case_num; j++)
    {
        if (column[j].row == i)
        {
            result.Add(j);
        }
    }
    if (b < result.Max() + 1 - result.Min())
    {
        b = result.Max() + 1 - result.Min();
        a = i;
    }
}
wr.WriteLine("{0} {1}", a, b);
wr.Close();


void Inorder(int A, int row)
{
    if (map[A].left != -1)
    {
        Inorder(map[A].left, row + 1);
    }
    column.Add((A, row));
    if (map[A].right != -1)
    {
        Inorder(map[A].right, row + 1);
    }
}