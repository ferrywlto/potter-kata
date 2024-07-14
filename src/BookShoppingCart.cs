
public class BookShoppingCart
{
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
        var minCommonCount = groups.Min(x => x.Value);

        while(groups.Count > 0)
        {
            var emptyBookIds = new List<int>();
            foreach(var group in groups)
            {
                if (groups.Count == 1)
                {
                    cost += minCommonCount * 8;
                }
                else if (groups.Count == 2)
                {
                    cost += minCommonCount * 8 * 0.95;
                }
                else if (groups.Count == 3)
                {
                    cost += minCommonCount * 8 * 0.9;
                }
                groups[group.Key] -= minCommonCount;

                if (groups[group.Key] == 0)
                    emptyBookIds.Add(group.Key);
            }
            foreach (var bookId in emptyBookIds)
                groups.Remove(bookId);
        }
        return cost;
    }
}