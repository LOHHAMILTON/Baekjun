StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int input1 = int.Parse(sr.ReadLine());
int num = 1;
int count = 0;

while (input1 >0)
{
    input1 -= num;
    num++;
    count++;

    if(num > input1)
    {
        num = 1;
    }
}
sw.WriteLine(count);
sw.Close();