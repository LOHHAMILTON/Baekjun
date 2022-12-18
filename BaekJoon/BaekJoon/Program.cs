using System.Collections;
using System.Linq;
internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ');
        int[] input01 = new int[input.Length];
        bool isAscending = false;
        bool isDescending = false;

        for (int i = 0; i < input.Length; i++)
        {
            input01[i] = int.Parse(input[i]);
        }

        for (int i = 1; i < input01.Length; i++)
        {
            if (input01[i] > input01[i - 1])
            {
                isAscending = true;
            }
            else
            {
                isAscending = false;
                break;
            }
        }
        for (int i = 1; i < input01.Length; i++)
        {
            if (input01[i] < input01[i - 1])
            {
                isDescending = true;
            }
            else
            {
                isDescending = false;
                break;
            }
        }

        if(isAscending ) 
        {
            Console.WriteLine("ascending");
        }
        else if(isDescending)
        {
            Console.WriteLine("descending");
        }
        else if(isAscending == false && isDescending == false)
        {
            Console.WriteLine("mixed");

        }

    }
}
