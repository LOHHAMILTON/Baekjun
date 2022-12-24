using System.Security.Cryptography;
using System.Text;
using System;

internal class program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(sr.ReadLine()));
        StringBuilder stringBuilder = new();
        foreach (byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }
        Console.WriteLine(stringBuilder.ToString());
    }
}