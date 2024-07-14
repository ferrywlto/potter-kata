namespace PotterKata.UnitTests;

public class BookShoppingCartTests 
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Add_OnIdLessThanOne_ReturnFalse(int bookId)
    {
        var sut = new BookShoppingCart();
        var actual = sut.Add(bookId);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(10)]
    public void Add_OnIdLargerThanFive_ReturnFalse(int bookId)
    {
        var sut = new BookShoppingCart();
        var actual = sut.Add(bookId);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void Add_OnBookIdBetweenOneToFive_ReturnTrue(int bookId)
    {
        var sut = new BookShoppingCart();
        var actual = sut.Add(bookId);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(new int[] { 0, -1, 6, 10 })]
    public void Add_OnInvalidId_CartItemCountShouldNotIncrease(int[] bookIds)
    {
        var sut = new BookShoppingCart();
        foreach(var id in bookIds)
        {
            int beforeCount = sut.Count;
            sut.Add(id);
            int afterCount = sut.Count;
            Assert.Equal(beforeCount, afterCount);
        }
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    public void Add_OnValidId_CartItemCountShouldIncreaseByOne(int[] bookIds)
    {
        var sut = new BookShoppingCart();
        foreach(var id in bookIds)
        {
            int beforeCount = sut.Count;
            sut.Add(id);
            int afterCount = sut.Count;
            Assert.Equal(beforeCount + 1, afterCount);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Calculate_OnAnySingleBook_ShouldReturnEight(int bookId)
    {
        var sut = new BookShoppingCart();
        sut.Add(bookId);

        var actual = sut.Calculate();
        Assert.Equal(8, actual);
    }

    [Fact]
    public void Calculate_OnEmptyCart_ShouldReturnZero()
    {
        var sut = new BookShoppingCart();
        var actual = sut.Calculate();
        Assert.Equal(0, actual);
    }
}