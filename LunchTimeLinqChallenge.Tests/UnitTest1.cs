using System.Globalization;
using System.Linq;

namespace LunchTimeLinqChallenge.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        string listOfNames = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
        string expected = "1. Davis,2. Clyne,3. Fonte,4. Hooiveld,5. Shaw,6. Davis,7. Schneiderlin,8. Cork,9. Lallana,10. Rodriguez,11. Lambert"; 

        Assert.Equal(expected, ChallengeSolution.One(listOfNames));
    }

    [Fact]
    public void Test2()
    {
        var soccerPlayers = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
        var first = ChallengeSolution.Two(soccerPlayers).FirstOrDefault(); 
        
        Assert.Equal("Kelvin Davis, 29/09/1976", first);
    }

    [Fact]
    public void Test3()
    {
        var songTimes = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27"; 
        var expectedAlbumLength = 38.38;
        
        Assert.Equal(expectedAlbumLength, Math.Round(ChallengeSolution.Three(songTimes), 2));
    }

    [Fact]
    public void Test4()
    {
        // plot points for 3 by 3 grid
        var expectedGridPoints = new string[]{"0,0", "0,1", "0,2", "1,0", "1,1", "1,2", "2,0", "2,1", "2,2"}.ToList();

        var actualGridPoints = ChallengeSolution.Four(3);
        Assert.True(CompareLists(expectedGridPoints, actualGridPoints));    
    }

    static bool CompareLists(List<string> list1, IEnumerable<string> list2)
    {
        if (list1.Count != list2.Count())
            return false;
        
        return !list1.Except(list2).Any() || list2.Except(list1).Any();
    }
}

public static class ChallengeSolution
{
    public static string One(string names)
    {
        names = string.Join("", names.Split(' ').Select((name, index) => $"{index + 1}. {name}"));
        return names;
    }

    public static IEnumerable<string> Two(string names)
    {
        var orderedNames = names.Split(';').OrderBy((date) => 
            new {
                    date = DateTime.ParseExact(date.Split(',')[1].Trim(), "dd/MM/yyyy", null)
                }
                .date)
                .Select((name) => name.Trim());

        return orderedNames;
    }

    public static double Three(string songTimes)
    {
        // TODO: try with TimeSpan.FromMinutes
        var albumLength = songTimes.Split(',').Sum((time) => double.Parse(time.Split(":")[0]) + (double.Parse(time.Split(":")[1]) / 60));
        return albumLength;
    } 

    public static IEnumerable<string> Four(int square)
    { 
        /*List<String> values = new List<String>();

        //       x,y    x,y    x,y
        // 0 -> (0,0), (0,1), (0,2) 
        // 1 -> (1,0), (1,1), (1,2)
        // 2 -> (2,0), (2,1), (2,2)

        for (int i = 0; i <= 2; i++)
        {
            for (int y = 0; y <= 2; y++)
            {
                values.Add($"{i}, {y}");            
            }
        }
            Translating the above into a linq query
        */

        var result = Enumerable.Range(0, square).SelectMany((point) => Enumerable.Range(0, square)
                               .Select(val => $"{point},{val}")
                               .ToList());

        return result;
    }
}