using System.Text;
using System.IO;

internal class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    //new BufferedStream(Console.OpenStandardInput()) stream?
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
    static void Main(string[] args)
    {
        int size = int.Parse(rd.ReadLine()); // 3의 두배만큼 문제가 주어짐
        
        for(int i = 0; i < size; i++)
        {
            string[] input1 = rd.ReadLine().Split(' ');
            int index = int.Parse(input1[1]);
            string[] input2 = rd.ReadLine().Split(' ');
            var raw = Array.ConvertAll(input2, int.Parse);

            Queue<int> queue = new Queue<int>();

            for(int j = 0; j < input2.Length; j++)
            {
                queue.Enqueue(raw[j]);
            }


        }
    }

}