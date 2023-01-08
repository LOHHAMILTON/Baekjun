using var sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

int n = ScanInt(), k = ScanInt();
var array = new int[n];
for (int i = 0; i < n; i++)
    array[i] = ScanInt();
Array.Sort(array);
Console.Write(array[k - 1]);

int ScanInt()
{
    int c = sr.Read(), ret = 0;
    if (c != '-')
    {
        ret = c - '0';
        while (!((c = sr.Read()) is '\n' or ' ' or -1))
        {
            if (c == '\r')
            {
                sr.Read();
                break;
            }
            ret = 10 * ret + (c - '0');
        }
    }
    else
    {
        while (!((c = sr.Read()) is '\n' or ' ' or -1))
        {
            if (c == '\r')
            {
                sr.Read();
                break;
            }
            ret = 10 * ret - (c - '0');
        }
    }
    return ret;
}
