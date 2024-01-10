using System;

namespace ЕГЭ
{
    internal static class Program
    {
        static void Main()
        {
            string path = @"C:\Users\*USERNAME*\Downloads\24.1.txt";
            StreamReader reader = new StreamReader(path);

            string[] lines = reader.ReadToEnd().Split('\n');
            reader.Close();
            
            int total = 0;

            foreach (string line in lines)
            {
                int amountSharps = 0;
                foreach (char symbol in line)
                {
                    if (symbol == '#')
                        amountSharps++;
                }

                float coefficient = (amountSharps / (float)line.Length) * 100;
                total += (int)coefficient;
            }
            
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
