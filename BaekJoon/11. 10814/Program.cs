public class man
{
    public int age;
    public string name;
    public man(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());
    static void Main()
    {
        List<man> map = new();
        int size = int.Parse(rd.ReadLine());

        for (int i = 0; i < size; i++)
        {
            string[] input = rd.ReadLine().Split(' ');
            map.Add(new man(int.Parse(input[0]), input[1]));
            for(int j = 0; j < map.Count-1; j++)
            {
                if (map[j].age > map[j + 1].age)
                {
                    (map[j].age, map[j + 1].age) = (map[j + 1].age, map[j].age);
                }
                else break;
            }
        }

        for (int i = 0; i < map.Count(); i++)
        {
            wr.WriteLine("{0} {1}", map[i].age, map[i].name);
        }
        wr.Close();
    }
}