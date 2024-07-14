# Potter Kata Book Store
This program will ask for inputting the book id (1 to 5) one by one.
When receiving the 'exit' command the program will calculate and display the total cost of the books in the cart. 

## Assumptions
The program assume the following:
- It will always attempt to calculate the highest discount (i.e 5 different books) first.
- Invalid book id input will get ignored instead of terminating the program.
- Results are rounded to two decimal places.

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

## Test Coverage
```xml
<package name="PotterKata" line-rate="1" branch-rate="1" complexity="40">
<class name="BookShoppingCart" filename="BookShoppingCart.cs" line-rate="1" branch-rate="1" complexity="22">
<class name="Program" filename="Program.cs" line-rate="1" branch-rate="1" complexity="18">
```