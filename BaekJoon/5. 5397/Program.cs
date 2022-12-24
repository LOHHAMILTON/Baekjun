using System.Text;
internal class program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        LinkedList<char> list = new LinkedList<char>();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < size; i++)
        {
            int index = 0;
            string input = Console.ReadLine();
            for (int j = 0; j < input.Length; j++)
            {
                char ints = input[j];
                switch (ints)
                {
                    case '<':
                        index = (index == 0 ? 0 : index -= 1);
                        break;
                    case '>':
                        if (index == 0)
                        {
                            index = 0;
                        }
                        else if (index != list.Count)
                        {
                            index++;
                        }
                        break;
                    case '-':
                        if (list.Count > 0)
                        {
                            LinkedListNode<char> node = list.First;

                            for (int k = 0; k < index-1; k++)
                            {
                                node = node.Next;
                            }

                            list.Remove(node);
                            index--;
                        }
                        break;
                    default:
                        if (list.Count != 0)
                        {
                            LinkedListNode<char> node = list.First;
                            if (list.Count != 1)
                            {
                                for (int k = 0; k < index-1; ++k)
                                {
                                    node = node.Next;
                                }
                            }
                            list.AddAfter(node, input[j]);
                            index++;
                        }
                        else
                        {
                            list.AddFirst(input[j]);
                            index++;
                        }
                        break;
                }
            }
            LinkedListNode<char> node1 = list.First;
            for (int j = 0; j < list.Count; j++)
            {
                sb.Append(node1.Value);
                node1 = node1.Next;
            }
            sb.Append("\n");
            list.Clear();
        }
        Console.WriteLine(sb);
    }
}