using System;
using System.Text;

namespace ЕГЭ
{
    internal static class Program
    {
        static void Main()
        {
            string path = @"C:\Users\*USERNAME*\Downloads\24.2.txt";
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();
            reader.Close();

            int levelWidth = 0;
            int levelHeight = 0;

            foreach (char symbol in line)
            {
                if (symbol == '@')
                    levelWidth++;
                else
                    break;
            }

            levelWidth--;
            levelHeight = line.Length / levelWidth;

            char[,] level = new char[levelWidth, levelHeight];
            int pointer = 0;

            for (int y = 0; y < levelHeight; y++)
            {
                for (int x = 0; x < levelWidth; x++)
                {
                    level[x, y] = line[pointer];
                    pointer++;
                }
            }

            List<int> cellProfits = new List<int>();

            for (int y = 1; y < levelHeight - 1; y++)
            {
                for (int x = 1; x < levelWidth - 1; x++)
                {
                    if (char.IsDigit(level[x, y]) == false)
                        continue;

                    int currentProfit = level[x, y] - '0'; //из char в int

                    currentProfit += char.IsDigit(level[x, y + 1]) ? level[x, y + 1] - '0' : 0;
                    currentProfit += char.IsDigit(level[x, y - 1]) ? level[x, y - 1] - '0' : 0;
                    currentProfit += char.IsDigit(level[x + 1, y]) ? level[x + 1, y] - '0' : 0;
                    currentProfit += char.IsDigit(level[x - 1, y]) ? level[x - 1, y] - '0' : 0;
                    
                    cellProfits.Add(currentProfit);
                }
            }

            float averageProfit = cellProfits.Sum() / (float)cellProfits.Count;

            int total = 0;

            foreach (int cellProfit in cellProfits)
            {
                if (cellProfit > averageProfit)
                    total++;
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
