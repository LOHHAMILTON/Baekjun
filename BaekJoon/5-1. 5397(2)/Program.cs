using System.Linq;
using System.Text;
internal class program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int size = int.Parse(sr.ReadLine());

        Stack<char> left, right;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < size; i++)
        {
            left = new Stack<char>();
            right = new Stack<char>();


            string input = sr.ReadLine();

            for (int j = 0; j < input.Length; j++)
            {
                char ints = input[j];
                switch (ints)
                {
                    case '<':
                        if(left.Count != 0)
                        {
                            right.Push(left.Pop());
                        }
                        break;
                    case '>':
                        if (right.Count != 0)
                        {
                            left.Push(right.Pop());
                        }
                        break;
                    case '-':
                        if (left.Count != 0)
                        {
                            left.Pop();
                        }
                        break;
                    default:
                        left.Push(input[j]);
                        break;
                }
            }

            Stack<char> print = new Stack<char>();
            while (left.Count > 0)
            {
                right.Push(left.Pop());
            }

            while (right.Count > 0)
            {
                sb.Append(right.Pop());
            }

            sb.Append("\n");
        }
        sw.WriteLine(sb);
        sw.Close();
    }
}