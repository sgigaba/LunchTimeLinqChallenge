using System.Globalization;

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
        var expectedAlbumLength = 38.4;
        
        Assert.Equal(expectedAlbumLength, ChallengeSolution.Three(songTimes));
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
                    date = DateTime.ParseExact(date.Split(',')[1].Trim(), "dd/MM/yyyy", null),
                }
                .date)
                .Select((name) => name.Trim());

        return orderedNames;
    }


    public static int Three(string songTimes)
    {
        return 0;
    } 
}