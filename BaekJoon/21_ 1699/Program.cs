StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


int input1 = int.Parse(sr.ReadLine());

int count = 0;
int[] ints = new int[100001];
int[] cache = new int[100001];

for (int i = 1; i < input1+ 1; ++i)
{
    cache[i] = i;
}

for( int i = 1; i < input1+1; ++i)
{
    for(int j = 1; j * j <= i; ++j)
    {
        cache[i] = Math.Min(cache[i], cache[i - j*j]+1);
    }
}

sw.WriteLine(cache[input1]);
sw.Close();