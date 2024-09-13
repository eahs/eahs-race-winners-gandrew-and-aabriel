using System.Collections.Generic;
using System.Threading.Tasks;
using RaceWinners.Models;

namespace RaceWinners;

public class DataService
{
    public async Task<List<Group>> GetGroupRanksAsync()
    {
        var groups = new List<Group>();
        
        // Simulate a little bit of delay as if we were loading this from a network
        await Task.Delay(1000);  // 1 second of delay

        // Add a group
        groups.Add(new Group
        {
            Name = "Class A",
            Ranks = new List<int> {4, 9, 11, 12, 20, 21, 25, 26, 29, 35, 43, 45, 49, 54, 61, 65, 69, 70, 71}  // etc
        });

        groups.Add(new Group
        {
            Name = "Class B",
            Ranks = new List<int> {6, 7, 10, 13, 16, 22, 24, 27, 34, 39, 40, 42, 48, 52, 53, 62, 66, 72}  // etc
        });

        groups.Add(new Group
        {
            Name = "Class C",
            Ranks = new List<int> {1, 3, 14, 18, 19, 23, 28, 30, 32, 41, 44, 47, 50, 56, 60, 63, 64, 68, 73, 74}  // etc
        });

        groups.Add(new Group
        {
            Name = "Class D",
            Ranks = new List<int> {2, 5, 8, 15, 17, 31, 33, 36, 37, 38, 46, 51, 55, 57, 58, 59, 67}  // etc
        });

        return groups;
    }
}
