using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RaceWinners;

public class Program
{
    static async Task Main(string[] args)
    {
        DataService ds = new DataService();

        // Asynchronously retrieve the group (class) data
        var data = await ds.GetGroupRanksAsync();

        // print the ranks
        for (int i = 0; i < data.Count; i++)
        {
            // Combine the ranks to print as a list
            var ranks = String.Join(", ", data[i].Ranks);
            
            Console.WriteLine($"{data[i].Name} - [{ranks}]");
        }
        
        // find the length of the smallest group
        int minRanks = data.Min(group => group.Ranks.Count);

        // Cut larger lists to make each group the same size
        foreach (var group in data)
        {
            if (group.Ranks.Count > minRanks)
            {
                group.Ranks.RemoveRange(minRanks, group.Ranks.Count - minRanks);
            }
        }

        double[] averages = new double[data.Count];
        int lowestAverageIndex = 0;

        // calculate average of each group
        for (int group = 0; group < data.Count; group++)
        {
            double average = Math.Round(data[group].Ranks.Average());
            averages[group] = average;

            if (average < averages[lowestAverageIndex])
            {
                lowestAverageIndex = group;
            }
        }

        Console.WriteLine();

        // print out the average of each class
        for (int group = 0; group < data.Count; group++)
        {
            string classAndAverage = $"Group {data[group].Name}'s average is: " + averages[group];
            // center the text in the console
            Console.SetCursorPosition((Console.WindowWidth - classAndAverage.Length) / 2, Console.CursorTop);
            Console.WriteLine(classAndAverage);
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;

        string winningClass = $"{data[lowestAverageIndex].Name} Wins!";

        // center the text in the console
        Console.SetCursorPosition((Console.WindowWidth - winningClass.Length) / 2, Console.CursorTop);

        Console.WriteLine(winningClass);

        Console.ResetColor();
    }
}