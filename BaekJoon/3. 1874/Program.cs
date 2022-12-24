using System;
using System.Linq;
using System.Text;
using System.Windows.Markup;

internal class program
{
    static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    //new BufferedStream(Console.OpenStandardInput()) stream?
    static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        int number = 0;
        Stack<int> stack = new Stack<int>();

        StringBuilder sb = new StringBuilder();
        int a = int.Parse(rd.ReadLine());
        for (int i = 0; i < a; i++)
        {
            list.Add(int.Parse(rd.ReadLine()));
        }
        for (int i = 1; i <= a; i++)
        {
            stack.Push(i);
            sb.Append("+" + "\n");

            while (stack.Count != 0 && stack.Peek() == list[number])
            {
                stack.Pop();
                sb.Append("-" + "\n");
                number++;
            }
        }
        if (stack.Count == 0)
        {
            wr.WriteLine(sb);
        }
        else
        {
            wr.WriteLine("NO");
        }
        wr.Close();
    }

}