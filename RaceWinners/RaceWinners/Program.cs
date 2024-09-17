using System;
using System.Linq;
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

        // find min number of ranks in all the groups
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

        // print out the averages
        for (int group = 0; group < data.Count; group++)
        {
            Console.WriteLine($"Group {data[group].Name}'s average is: " + averages[group]);
        }

        Console.WriteLine();

        Console.WriteLine($"Group {data[lowestAverageIndex].Name} Wins!");
    }
}