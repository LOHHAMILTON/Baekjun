StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int case_Num = int.Parse(sr.ReadLine());
List<int> list= new();
for(int i = 0; i < case_Num;i++)
{
    int input = int.Parse(sr.ReadLine());
    if (input == 0)
    {
        if (list.Count() == 0) sw.WriteLine(0);
        else
        {
            int a = list[0];
            sw.WriteLine(a);
            int last_node = list[list.Count - 1];
            list[0] = last_node;
            list.RemoveAt(list.Count - 1);

            int j = 0;
            int last = list.Count- 1;
            while (j < last)
            {
                int child = j * 2 + 1;
                if (child < last && list[child] > list[child + 1])
                {
                    child++;
                }
                if (child > last || list[j] <= list[child])
                {
                    break;
                }
                swap(j, child);
                j = child;
            }
        }
    }
    else if (input > 0)
    {
        list.Add(input);
        int last = list.Count - 1;
        while (last > 0)
        {
            int parent = (last - 1) / 2;
            if (list[parent] > list[last])
            {
                swap(parent, last);
                last = parent;
            }
            else break;
        }
    }
}
sw.WriteLine();
sw.Close();

void swap(int a, int b)
{
    int temp = list[a];
    list[a] = list[b];
    list[b] = temp;
}