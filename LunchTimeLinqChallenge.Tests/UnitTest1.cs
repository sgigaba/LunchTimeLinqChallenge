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
}

public static class ChallengeSolution
{
    public static string One(string names)
    {
        return names;
    }
    public static IEnumerable<string> Two(string names)
    {
        return Enumerable.Empty<string>();
    }
}