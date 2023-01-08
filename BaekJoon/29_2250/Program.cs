StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int case_num = int.Parse(rd.ReadLine());

List<int> column = new();
column.Add(0);

Dictionary<int, (int left, int right)> map = new();

for (int i = 0; i < case_num; i++)
{
    int[] input = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
    map.Add(input[0], (input[1], input[2]));
}

Inorder(1);
wr.Close();


void Inorder(int A)
{
    if (map[A].left != -1)
    {
        Inorder(map[A].left);
    }
    column.Add(A);
    if (map[A].right != -1)
    {
        Inorder(map[A].right);
    }

}

S