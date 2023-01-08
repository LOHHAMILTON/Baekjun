using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Program
{
    static Node[] nodes;
    static int[] visit;
    static int[] min, max;
    class Node
    {
        public int Item { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int item, Node left = null, Node right = null)
        {
            Item = item;
            Left = left;
            Right = right;
        }
    }

    static Node GetNode(int idx)
    {
        if (idx == -1) return null;
        if (nodes[idx] == null)
        {
            nodes[idx] = new Node(idx);
        }

        return nodes[idx];
    }

    static int DFS(Node node)
    {
        ref int ret = ref visit[node.Item];
        if (ret != 0) return ret;

        ret = 1;
        if (node.Right != null) ret += DFS(node.Right);

        if (node.Left != null) ret += DFS(node.Left);

        return ret;
    }

    static void f(int rootIndx, int startWidth, int height)
    {
        var leftNode = GetNode(rootIndx).Left;
        var rightNode = GetNode(rootIndx).Right;

        int leftWidth, rightWidth;

        int middle;
        if (leftNode != null)
        {
            middle = startWidth + visit[leftNode.Item] + 1;
        }
        else
        {
            middle = startWidth + 1;
        }

        if (leftNode == null)
        {
            leftWidth = -1;
        }
        else
        {
            if (leftNode.Left == null) leftWidth = startWidth + 1;
            else
            {
                leftWidth = startWidth + visit[leftNode.Left.Item] + 1;
            }

            f(leftNode.Item, startWidth, height + 1);
        }

        if (rightNode == null)
        {
            rightWidth = -1;
        }
        else
        {
            if (rightNode.Left == null) rightWidth = middle + 1;
            else rightWidth = middle + visit[rightNode.Left.Item] + 1;

            f(rightNode.Item, middle, height + 1);
        }


        int ma = Math.Max(leftWidth, rightWidth);
        max[height] = Math.Max(ma, ma);

        int mi = 100000000;

        if (leftWidth != -1)
        {
            mi = Math.Min(mi, leftWidth);
        }

        if (rightWidth != -1)
        {
            mi = Math.Min(mi, rightWidth);
        }

        min[height] = Math.Min(min[height], mi);
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        nodes = new Node[n + 1];

        int[] cnt = new int[n + 2];

        for (int i = 0; i < n; i++)
        {
            args = Console.ReadLine().Split();

            if (int.Parse(args[1]) != -1)
            {
                cnt[int.Parse(args[1])]++;
            }

            if (int.Parse(args[2]) != -1)
            {
                cnt[int.Parse(args[2])]++;
            }

            var p = GetNode(int.Parse(args[0]));

            var l = GetNode(int.Parse(args[1]));
            var r = GetNode(int.Parse(args[2]));

            p.Left = l;
            p.Right = r;
        }

        visit = new int[n + 1];

        int rootidx = 1;

        for (int i = 1; i <= n; i++)
        {
            if (cnt[i] == 0)
            {
                rootidx = i;
            }
        }

        DFS(nodes[rootidx]);


        min = new int[500];
        max = new int[500];

        for (int i = 0; i < 500; i++)
        {
            min[i] = 100000000;
        }

        f(rootidx, 0, 0);
        int idx = 0;
        int result = 0;
        int reusltIdx = 0;
        while (true)
        {
            if (min[idx] == 100000000 || max[idx] == 0)
            {
                break;
            }

            if (result < max[idx] - min[idx])
            {
                result = max[idx] - min[idx];
                reusltIdx = idx;
            }
            idx++;
        }

        if (reusltIdx != 0) reusltIdx += 2;
        else reusltIdx++;
        result += 1;
        Console.Write(reusltIdx + " " + result);
    }
}