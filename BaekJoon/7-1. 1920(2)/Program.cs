using var rs = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
using var ws = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

var _ = int.Parse(rs.ReadLine());
var targetElements = rs.ReadLine().Split().ToHashSet();
_ = int.Parse(rs.ReadLine());
var findElements = rs.ReadLine().Split();

foreach (var item in findElements)
{
    if (targetElements.Contains(item))
        ws.WriteLine("1");
    else
        ws.WriteLine("0");
}