using System.Text;

internal class Program
{
    static void Main( )
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder sb = new();
        sr.ReadLine();
        int[] inputA = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

        Dictionary<int, int> map = new Dictionary<int, int>();

        for(int i = 0; i < inputA.Length; i++)
        {
            map[inputA[i]] = i;
        }
        sr.ReadLine();
        int[] inputB = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
        for(int i = 0; i < inputB.Length; i++)
        {
            if (map.ContainsKey(inputB[i]))
            {
                sb.AppendLine("1");
            }
            else sb.AppendLine("0");
        }
        sw.WriteLine(sb);
        sw.Close();
    }
}