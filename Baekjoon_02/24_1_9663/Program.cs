public class Test2
{
    int N;
    int count;
    bool[] isUsed1;
    bool[] isUsed2;
    bool[] isUsed3;
    public int N_Queen(int n)
    {
        N = n;
        count = 0;
        isUsed1 = new bool[30];
        isUsed2 = new bool[30];
        isUsed3 = new bool[30];
        fncN_Queen(0);
        return count;
    }

    void fncN_Queen(int y)
    {
        if (y == N)
        {
            ++count;
            return;
        }

        for (int x = 0; x < N; ++x)
        {
            if (isUsed1[x] || isUsed2[x + y] || isUsed3[y - x + N - 1]) continue;
            isUsed1[x] = isUsed2[x + y] = isUsed3[y - x + N - 1] = true;
            fncN_Queen(y + 1);
            isUsed1[x] = isUsed2[x + y] = isUsed3[y - x + N - 1] = false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Test2 t = new Test2();
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine(t.N_Queen(c));
    }
}