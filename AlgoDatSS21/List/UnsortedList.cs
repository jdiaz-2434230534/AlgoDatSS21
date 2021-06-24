namespace AlgoDatSS21
{
    public abstract class UnsortedList: List
    {
        protected override ListSearchResult _search_(int elem)
        {
            // No entries in List
            if (root == null)
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
                
                current = current.next;
            }
            return new ListSearchResult(false, current);
        }
    }
}