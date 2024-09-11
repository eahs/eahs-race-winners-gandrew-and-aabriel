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
            Ranks = new List<int> {4, 9, 11, 12, 20}  // etc
        });

        return groups;
    }
}
