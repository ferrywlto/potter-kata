using System.Diagnostics.CodeAnalysis;
[ExcludeFromCodeCoverage]
public partial class Program
{
    const string exitCommand = "exit";
    const string inputMessage = "Add a book to cart (input 'exit' to finish): ";
    const string welcomeMessage = "Welcome to Potter Kata book store!";
    const string invalidInputMessage = "Invalid input, please enter again";
    const string resultMessage = "The total price of the books is: €";

    public static void Main(string[] args)
    {
        Console.WriteLine(welcomeMessage);

        var cart = new BookShoppingCart();

        string? input;
        while (true)
        {
            Console.Write(inputMessage);
            input = Console.ReadLine()?.ToLower();
            
            if(string.IsNullOrEmpty(input)) 
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }
            if (input.Equals(exitCommand)) break;
            
            if(!(int.TryParse(input, out var value) && cart.Add(value))) 
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }
        }
        Console.Write(resultMessage);
        Console.WriteLine(Math.Round(cart.Calculate(),2));
    }
}