public class BookShoppingCart
{
    const int baseBookPriceInEuro = 8;
    const float noDiscount = 1;
    const float twoDifferentBooksDiscount = 0.95f;
    const float threeDifferentBooksDiscount = 0.9f;
    const float fourDifferentBooksDiscount = 0.8f;
    const float fiveDifferentBooksDiscount = 0.75f;

    private List<int> cartItems = [];
    public int Count => cartItems.Count;
    public bool Add(int bookId)
    {
        if (bookId < 1 || bookId > 5) return false;
        cartItems.Add(bookId);
        return true;
    }

    public double Calculate()
    {
        if (cartItems.Count == 0) return 0;

        double cost = 0;
        var groups = cartItems.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        while(groups.Count > 0)
        {
            var minCommonCount = groups.Min(x => x.Value);
            cost += minCommonCount * groups.Count * baseBookPriceInEuro * DetermineDiscount(groups.Count);

            var emptyBookIds = new List<int>();
            foreach(var group in groups)
            {
                groups[group.Key] -= minCommonCount;

                if (groups[group.Key] <= 0)
                    emptyBookIds.Add(group.Key);
            }
            foreach (var bookId in emptyBookIds)
                groups.Remove(bookId);
        }
        return cost;
    }
    public float DetermineDiscount(int numDiffBooks) => numDiffBooks switch
    {
        2 => twoDifferentBooksDiscount,
        3 => threeDifferentBooksDiscount,
        4 => fourDifferentBooksDiscount,
        5 => fiveDifferentBooksDiscount,
        _ => noDiscount
    };
}