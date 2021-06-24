namespace AlgoDatSS21
{
    public abstract class SortedList: List
    {
        protected override ListSearchResult _search_(int elem)
        {
            // No entries in List or elem is smaller than root
            if (root == null || root.value > elem)
            {
                return new ListSearchResult(false, null);
            }

            // elem is root
            if (root.value == elem)
            {
                return new ListSearchResult(true, null);
            }
            
            var current = root;
            while (current.next != null)
            {
                if (current.next.value == elem)
                {
                    return new ListSearchResult(true, current);
                }

                if (current.next.value > elem)
                {
                    break;
                }

                current = current.next;
            }
            return new ListSearchResult(false, current);
        }
    }
}