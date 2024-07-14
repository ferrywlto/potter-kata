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
}