using System;
using System.Text;

namespace ЕГЭ
{
    internal static class Program
    {
        static void Main()
        {
            string path = @"C:\Users\*USERNAME*\Downloads\24.3.txt";
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();
            reader.Close();

            int total = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != '4' || !char.IsDigit(line[i + 1]) || !char.IsDigit(line[i + 2]))
                    continue;

                int codeEnding = int.Parse(line[i + 1].ToString() + line[i + 2]);

                if (codeEnding == 18)
                {
                    total += 5;
                    continue;
                }

                bool isValidCodeEnding = codeEnding is
                    >= 0 and <= 19 or
                    >= 21 and <= 26 or
                    28 or 29 or 31 or
                    49 or 51 or 99;

                if (isValidCodeEnding)
                    total++;
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
