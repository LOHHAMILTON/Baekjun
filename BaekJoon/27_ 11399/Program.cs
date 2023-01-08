StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
int input_01 = int.Parse(rd.ReadLine());
int[] input_02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse);
Array.Sort(input_02);
int time = 0;
int a = 0;

for (int i = 0; i< input_02.Length; i++)
{
    a += input_02[i];
    time += a;
}
wr.WriteLine(time);
wr.Close();