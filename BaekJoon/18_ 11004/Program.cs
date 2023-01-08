using System;
using System.IO;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] input1 = sr.ReadLine().Split(' ');
int index = int.Parse(input1[1]);

int[] input2 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

Array.Sort(input2);

sw.WriteLine(input2[index - 1]);
sw.Close();
sr.Close();