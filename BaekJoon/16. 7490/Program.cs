using System.Text;

class program
{
    static StreamReader rd = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    static StreamWriter wr = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        int testcase = int.Parse(rd.ReadLine());
        for (int i = 0; i < testcase; i++)
        {
            int num = int.Parse(rd.ReadLine());
            int[] operation = new int[num -1];


            void findzero(int prevnum, int next, int result) // 덧셈, 뺄셈은 result에, spacenum은 prev에
            {
                if (next == num)
                {
                    result = prevnum + result;
                    if(result == 0 )
                    {
                        for (int i = 0; i < num; i++)
                        {
                            sb.Append(i + 1);
                            if (operation[i] == 1) { sb.Append(' '); }
                            if (operation[i] == 2) { sb.Append('+'); }
                            if (operation[i] == 3) { sb.Append("-"); }  
                        }
                    }

                }

                int spacenum = 0;
                if(prevnum < 0) { spacenum = prevnum * 10 - next; }   
                else { spacenum = prevnum * 10 + next; }
                operation[next - 2] = 1;
                findzero(spacenum, next+1, result);
                operation[next - 2] = 0;

                int plusnum = prevnum + result;
                operation[next - 2] = 2;
                findzero(next, next + 1, plusnum); 
                operation[next - 2] = 0;

                int minusnum = prevnum + result;
                operation[next - 2] = 3;
                findzero(-next, next + 1, minusnum);
                operation[next - 2] = 0;



            }
        }


    }
}