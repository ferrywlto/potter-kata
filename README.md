# Potter Kata Book Store
This program will ask for inputting the book id (1 to 5) one by one.
When receiving the 'exit' command the program will calculate and display the total cost of the books in the cart. 

## Assumptions
The program assume the following:
- It will always attempt to calculate the highest discount (i.e 5 different books) first.

## Getting started

### Pre-requisite
- .NET 8 SDK installed 

### Run the program
```bash
cd src
dotnet run
```

### Run the unit tests
```bash
cd tests
dotnet test
``` 

## Sample output
```
Welcome to Potter Kata book store!
Add a book to cart (input 'exit' to finish): 1
Add a book to cart (input 'exit' to finish): exit
The total amount of the cart is: €8
```