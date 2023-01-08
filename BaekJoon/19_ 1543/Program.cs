StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string input1 = sr.ReadLine();
string input2 = sr.ReadLine();
int index = 0;
int count = 0;

find(input1, input2, 0);
sw.WriteLine(count);
sw.Close();
sr.Close();

void find(string input1, string input2, int Index)
{
    if(index > input1.Length -input2.Length)
    {
        return;
    }
    if (input1[index] == input2[0])
    {
        if (input1.Substring(index, input2.Length).Equals(input2))
        {
            count++;
            index += input2.Length;
            find(input1, input2, index);
        }
        else
        {
            index++;
            find(input1, input2, index);
        }
    }
    else
    {
        index++;
        find(input1, input2, index);
    }
}
