Console.WriteLine("Welcome to Potter Kata book store!");

const string inputMessage = "Add a book to cart (input 'exit' to finish): ";
var cart = new BookShoppingCart();

string? input;
do
{
    Console.Write(inputMessage);
}
while ((input = Console.ReadLine()?.ToLower()) != "exit");

Console.WriteLine($"The total of the cart is: £{10}");