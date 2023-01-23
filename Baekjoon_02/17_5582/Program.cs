StreamReader rd = new StreamReader(Console.OpenStandardInput());
StreamWriter wr = new StreamWriter(Console.OpenStandardOutput());

int[] change_list = { 500, 100, 50, 10, 5, 1 }; 

int input = 1000 - int.Parse(rd.ReadLine());
int count = 0;

for(int i = 0; i < change_list.Length; i++)
{
    while(input >= change_list[i])
    {
        input -= change_list[i];
        count++;
    }
}


wr.WriteLine(count);
wr.Close();
