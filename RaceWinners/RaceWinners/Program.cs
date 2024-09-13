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

        int minRanks = data[0].Ranks.Count;

        // find min number of ranks in all the groups
        for (int group = 1; group < data.Count; group++)
        {
            if (data[group].Ranks.Count < minRanks)
            {
                minRanks = data[group].Ranks.Count;
            }
        }

        // cut bigger lists to make each group the same size
        for (int group = 0; group < data.Count; group++)
        {
            while (data[group].Ranks.Count > minRanks)
            {
                data[group].Ranks.RemoveAt(data[group].Ranks.Count - 1);
            }
        }

        float[] averages = new float[data.Count];
        int lowestAverageIndex = 0;

        // calculate average of each group
        for (int group = 0; group < data.Count; group++)
        {

            int average = 0;

            for (int rank = 0; rank < data[group].Ranks.Count; rank++)
            {
                average += data[group].Ranks[rank];
            }

            average /= data[group].Ranks.Count;
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