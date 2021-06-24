namespace AlgoDatSS21
{
    class MultiSetSortedLinkedList : SortedList, IMultiSetSorted
    {
        public bool Insert(int x)
        {
            var searchResult = _search_(x);

            // Position is root
            if (searchResult.lastEntry == null)
            {
                root = new ListEntry(x, root);
                return true;
            }
            
            searchResult.lastEntry.next = new ListEntry(x, searchResult.lastEntry.next);
            return true;
        }
    }
}
