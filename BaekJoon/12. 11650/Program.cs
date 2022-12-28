public class person
{
    public int x;
    public int y;
    public person(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

    static void Main()
    {
        int num = int.Parse(rd.ReadLine());
        List<person> list = new();

        for (int i = 0; i < num; i++)
        {
            string[] input = rd.ReadLine().Split(' ');
            list.Add(new person(int.Parse(input[0]), int.Parse(input[1])));
        }

        list.Sort((x, y) => {
            int ret = x.x.CompareTo(y.x);
            return ret != 0 ? ret : x.y.CompareTo(y.y);
        });

        for (int i = 0; i < num; i++)
        {
            wr.WriteLine("{0} {1}", list[i].x, list[i].y);
        }

        wr.Close();
    }

}