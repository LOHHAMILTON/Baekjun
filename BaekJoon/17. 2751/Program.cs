
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        int case_Num = int.Parse(sr.ReadLine());
        int[] ints= new int[case_Num];
        for (int i = 0; i < case_Num; i++)
        {
            ints[i] = int.Parse(sr.ReadLine());
        }
        Array.Sort(ints);
        for (int i = 0; i < ints.Length; i++)
        {
            sw.WriteLine(ints[i]);
        }
        sw.Close();
        sr.Close();