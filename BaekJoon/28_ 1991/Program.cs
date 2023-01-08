StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int case_num = int.Parse(rd.ReadLine());
Dictionary<string, (string left, string right)> map = new();
for (int i = 0; i < case_num; i++)
{
    string[] input = rd.ReadLine().Split(' ');
    map.Add(input[0], (input[1], input[2]));
}
Preorder("A");
wr.WriteLine();
Inorder("A");
wr.WriteLine();
Postorder("A");
wr.Close();

void Preorder(string A)
{
    wr.Write(A);
    if (map[A].left != ".")
    {
        Preorder(map[A].left);
    }
    if (map[A].right != ".")
    {
        Preorder(map[A].right);
    }

}


void Inorder(string A)
{
    if (map[A].left != ".")
    {
        Inorder(map[A].left);
    }
    wr.Write(A);
    if (map[A].right != ".")
    {
        Inorder(map[A].right);
    }

}

void Postorder(string A)
{
    if (map[A].left != ".")
    {
        Postorder(map[A].left);
    }
    if (map[A].right != ".")
    {
        Postorder(map[A].right);
    }
    wr.Write(A);

}
