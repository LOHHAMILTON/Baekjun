using System.Collections.Generic;
using System.IO;
using System;

class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
    static List<int> link = new List<int>();
    static List<int> size = new List<int>();
    static int find(int x)
    {
        while (x != link[x])
            x = link[x];
        return x;
    }
    static void unite(int a, int b)
    {
        a = find(a);
        b = find(b);
        if (a != b)
        {
            if (size[a] > size[b])
            {
                size[a] += size[b];
                link[b] = a;
            }

            else
            {
                size[b] += size[a];
                link[a] = b;
            }
        }
    }
    static void Main()
    {
        Dictionary<string, int> name = new Dictionary<string, int>();
        int num = int.Parse(rd.ReadLine());
        for (int i = 0; i < num; i++)
        {
            int num2 = int.Parse(rd.ReadLine());
            link.Clear();
            size.Clear();
            name.Clear();
            for (int j = 0; j < num2; j++)
            {
                string[] person = rd.ReadLine().Split(' ');
                if (!name.ContainsKey(person[0]))
                {
                    name.Add(person[0], name.Count);
                    link.Add(name[person[0]]);
                    size.Add(1);
                }

                if (!name.ContainsKey(person[1]))
                {
                    name.Add(person[1], name.Count);
                    link.Add(name[person[1]]);
                    size.Add(1);
                }
                unite(name[person[0]], name[person[1]]);
                int a = find(name[person[0]]);
                wr.WriteLine(size[a]);
            }
        }
        wr.Close();
    }
}