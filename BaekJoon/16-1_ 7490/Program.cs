using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _16_1__7490
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int casenum = int.Parse(sr.ReadLine());
            int N = 0;
            StringBuilder sb = new StringBuilder();
            for (int t = 0; t < casenum; t++)
            {
                N = int.Parse(sr.ReadLine()); //계산에 넣을 숫자 몇개

                int[] array = new int[N - 1]; // 연산자 갯수는 수 -1 개


                DFS(1, 2, 0); //깊이 우선 탐색

                sb.AppendLine(); // 한칸 띄고


                sb.Remove(sb.Length - 1, 1); //빈칸 제거
                sw.Write(sb);

                sr.Close();
                sw.Close();





                void DFS(int prevNum, int count, int result) //prevnum은 1 count는 2
                {
                    if (count == N + 1)
                    {
                        result = result + prevNum;
                        if (result == 0)
                        {
                            sb.Append(1);
                            for (int num = 2; num <= N; num++)
                            {
                                if (array[num - 2] == 1) sb.Append('+');
                                else if (array[num - 2] == 2) sb.Append('-');
                                else if (array[num - 2] == 3) sb.Append(' ');
                                sb.Append(num);
                            }
                            sb.AppendLine();
                        }
                        return;
                    }


                    // 한 칸 뛰기
                    int spaceNum = 0;
                    if (prevNum < 0) spaceNum = prevNum * 10 - count;
                    else spaceNum = prevNum * 10 + count;
                    array[count - 2] = 3;
                    DFS(spaceNum, count + 1, result); // 재귀함수
                    array[count - 2] = 0;

                    // 더하기
                    int plusResult = result + prevNum;
                    array[count - 2] = 1;
                    DFS(count, count + 1, plusResult); // 재귀함수
                    array[count - 2] = 0;

                    // 빼기
                    int minusResult = result + prevNum;
                    array[count - 2] = 2;
                    DFS(-count, count + 1, minusResult); // 재귀함수
                    array[count - 2] = 0;

                }
            }

        }
    }
}