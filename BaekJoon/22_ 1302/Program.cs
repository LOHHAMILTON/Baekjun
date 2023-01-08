class program
{
    static StreamReader rd = new StreamReader(Console.OpenStandardInput());
    static StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

    static void Main()
    {
        Dictionary<string, int> map = new();

        int case_num = int.Parse(rd.ReadLine());

        for (int t = 0; t < case_num; t++)
        {
            string input = rd.ReadLine();
            if (map.ContainsKey(input))
            {
                map[input]++;
            }
            else
            {
                map[input] = 1;
            }
        }
        List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>(map);

        list.Sort((x, y) =>
        {
            int ret = x.Value.CompareTo(y.Value)*(-1);
            return ret == 0  ? ret : string.Compare(x.Key, y.Key);
        });
        wr.WriteLine(list[0].Key);
        wr.Close();
    }

}