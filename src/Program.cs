public partial class Program
{
    const string exitCommand = "exit";
    const string inputMessage = "Add a book to cart (input 'exit' to finish): ";
    const string welcomeMessage = "Welcome to Potter Kata book store!";
    const string resultMessage = "The total price of the books is: €";
    const string invalidMessage = " is an invalid value and ignored.";
    const string emptyMessage = "Null or empty value ignored.";

    public static void Main(string[] args)
    {
        Console.WriteLine(welcomeMessage);

        var cart = new BookShoppingCart();
        if(args.Length == 1 && !string.IsNullOrEmpty(args[0]))
        {
            var bookIds = args[0].Split(',');
            foreach(var bookId in bookIds)
            {
                if(!(int.TryParse(bookId, out var value) && cart.Add(value))) 
                {
                    Console.Write(bookId);
                    Console.WriteLine(invalidMessage);
                }
            }
        }
        else
        {
            string? input;
            while (true)
            {
                Console.Write(inputMessage);
                input = Console.ReadLine();
                
                if(string.IsNullOrEmpty(input)) 
                {
                    Console.WriteLine(emptyMessage);
                    continue;
                }
                
                if (input.ToLower().Equals(exitCommand)) break;
                
                if(!(int.TryParse(input, out var value) && cart.Add(value))) 
                {
                    Console.Write(input);
                    Console.WriteLine(invalidMessage);
                    continue;
                }
            }
        }
        Console.Write(resultMessage);
        Console.WriteLine(Math.Round(cart.Calculate(),2));
    }
}