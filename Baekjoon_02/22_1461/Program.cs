StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
int[] input01 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); // 0 : 책의 수 1 : 최대 옮길수 있는 책

int[] input02 = Array.ConvertAll(rd.ReadLine().Split(' '), int.Parse); 

List<int> book01 = new();
List<int> book02 = new();

for(int i = 0; i < input02.Length; i++)
{
    if (input02[i] > 0) book01.Add(input02[i]);
    else book02.Add(input02[i]);
}

book01.Sort();
book01.Reverse();
book02.Sort();

int distance = 0;

if (book01.Count >0 && book02.Count> 0)
{
    if(book01[0] > Math.Abs(book02[0]))
    {
        for(int i = 0; i < book01.Count; i++)
        {
            distance += book01[i];
            if (i % input01[1] != 0)  distance -= book01[i];
        }
        for (int i = 0; i < book02.Count; i++)
        {
            distance += Math.Abs(book02[i]);
            if (i % input01[1] != 0) distance -= Math.Abs(book02[i]);
        }
        distance *= 2;
        distance -= book01[0];
    }
    else
    {
        for (int i = 0; i < book01.Count; i++)
        {
            distance += book01[i];
            if (i % input01[1] != 0) distance -= book01[i];
        }
        for (int i = 0; i < book02.Count; i++)
        {
            distance += Math.Abs(book02[i]);
            if (i % input01[1] != 0) distance -= Math.Abs(book02[i]);
        }
        distance *= 2;
        distance -= Math.Abs(book02[0]);
    }
}
else if (book01.Count == 0)
{
    for (int i = 0; i < book02.Count; i++)
    {
        distance += Math.Abs(book02[i]);
        if ((i) % input01[1] != 0) distance -= Math.Abs(book02[i]);
    }
    distance *= 2;
    distance -= Math.Abs(book02[0]);
}
else if( book02.Count == 0)
{
    for (int i = 0; i < book01.Count; i++)
    {
        distance += book01[i];
        if ((i) % input01[1] != 0) distance -= book01[i];
    }
    distance *= 2;
    distance -= book01[0];
}
wr.WriteLine(distance);
wr.Close();