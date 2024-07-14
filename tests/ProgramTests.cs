namespace PotterKata.UnitTests;

public class ProgramTests
{
    [Theory]
    [InlineData("1,2,3,4,x", "x")]
    [InlineData("1,2,3,-1","-1")]
    [InlineData("1,2,3,6", "6")]
    [InlineData("1,2,3,,6", "")]
    public void Main_PassBookIdsByArgs_DidIgnoredInvalidInput(string input, string invalid)
    {
        var originalOutput = Console.Out; 
        using var writer = new StringWriter();
        Console.SetOut(writer);

        Program.Main([input]); 
        Console.Out.Flush();
        var actual = writer.ToString();

        Assert.Contains($"{invalid} is an invalid value and ignored.", actual);
        Console.SetOut(originalOutput);
    }

    [Theory]
    [InlineData("1,2,3,4,x,exit", "x")]
    [InlineData("1,2,3,-1,exit","-1")]
    [InlineData("1,2,3,6,exit", "6")]
    public void Main_PassBookIdsByConsole_DidIgnoredInvalidInput(string input, string invalid)
    {
        var originalInput = Console.In;
        var originalOutput = Console.Out; 
        using var inputReader = new StringReader(input.Replace(",", "\n") + "\n");
        using var writer = new StringWriter();
        Console.SetIn(inputReader);
        Console.SetOut(writer);

        Program.Main([]); 
        Console.Out.Flush();
        var actual = writer.ToString();

        Assert.Contains($"{invalid} is an invalid value and ignored.", actual);
        Console.SetIn(originalInput);
        Console.SetOut(originalOutput);
    }

    [Theory]
    [InlineData("1,2,3,,exit")]
    public void Main_PassBookIdsByConsole_DidIgnoredEmpty(string input)
    {
        var originalInput = Console.In;
        var originalOutput = Console.Out; 
        using var inputReader = new StringReader(input.Replace(",", "\n") + "\n");
        using var writer = new StringWriter();
        Console.SetIn(inputReader);
        Console.SetOut(writer);

        Program.Main([]); 
        Console.Out.Flush();
        var actual = writer.ToString();

        Assert.Contains("Null or empty value ignored.", actual);
        Console.SetIn(originalInput);
        Console.SetOut(originalOutput);
    }
}
