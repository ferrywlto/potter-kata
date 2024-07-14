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

    [Theory]
    [InlineData(new int[] {1}, 8)]
    [InlineData(new int[] {2,2}, 16)]
    [InlineData(new int[] {3,3,3}, 24)]
    [InlineData(new int[] {4,4,4,4}, 32)]
    [InlineData(new int[] {5,5,5,5,5}, 40)]
    public void Calculate_OnMultipleSameBook_ShouldReturnMultipleOfEight(int[] bookIds, int expected)
    {
        var sut = new BookShoppingCart();
        foreach(var id in bookIds) sut.Add(id);
        var actual = sut.Calculate();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] {1,2})]
    [InlineData(new int[] {2,3})]
    [InlineData(new int[] {3,4})]
    [InlineData(new int[] {4,5})]
    [InlineData(new int[] {5,1})]
    public void Calculate_OnTwoDifferentBooks_ShouldApplyFivePercentsDiscounts(int[] bookIds)
    {
        const double expected = 2 * 8 * 0.95;
        var sut = new BookShoppingCart();
        foreach(var id in bookIds) sut.Add(id);
        var actual = sut.Calculate();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] {1,2,2})]
    [InlineData(new int[] {2,3,3})]
    [InlineData(new int[] {3,4,4})]
    [InlineData(new int[] {4,5,5})]
    [InlineData(new int[] {5,1,1})]
    public void Calculate_OnTwoDifferentBookPlusOneSameBook_ShouldAddEightForTheExtraBook(int[] bookIds)
    {
        const double expected = 2 * 8 * 0.95 + 8;
        var sut = new BookShoppingCart();
        foreach(var id in bookIds) sut.Add(id);
        var actual = sut.Calculate();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] {1,2,3})]
    [InlineData(new int[] {2,3,4})]
    [InlineData(new int[] {3,4,5})]
    [InlineData(new int[] {4,5,1})]
    [InlineData(new int[] {5,1,2})]
    public void Calculate_OnThreeDifferentBooks_ShouldApplyTenPercentsDiscounts(int[] bookIds)
    {
        const double expected = 3 * 8 * 0.9;
        var sut = new BookShoppingCart();
        foreach(var id in bookIds) sut.Add(id);
        var actual = sut.Calculate();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 3, 3 })]
    [InlineData(new int[] { 2, 3, 4, 4, 4 })]
    [InlineData(new int[] { 3, 4, 5, 5, 5 })]
    [InlineData(new int[] { 4, 5, 1, 1, 1 })]
    [InlineData(new int[] { 5, 1, 2, 2, 2 })]
    public void Calculate_OnThreeDifferentBooksPlusTwoSameBooks_ShouldAddSixteenForExtraBooks(int[] bookIds)
    {
        const double expected = 3 * 8 * 0.9 + 16;
        var sut = new BookShoppingCart();
        foreach(var id in bookIds) sut.Add(id);
        var actual = sut.Calculate();
        Assert.Equal(expected, actual);
    }    

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 })]
    [InlineData(new int[] { 2, 3, 4, 5 })]
    [InlineData(new int[] { 3, 4, 5, 1 })]
    [InlineData(new int[] { 4, 5, 1, 2 })]
    [InlineData(new int[] { 5, 1, 2, 3 })]
    public void Calculate_OnFourDifferentBooks_ShouldApplyTwentyPercentDiscounts(int[] bookIds)
    {
        const double expected = 4 * 8 * 0.8;
        var sut = new BookShoppingCart();
        foreach(var id in bookIds) sut.Add(id);
        var actual = sut.Calculate();
        Assert.Equal(expected, actual);
    }
}