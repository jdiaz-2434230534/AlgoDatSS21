namespace AlgoDatSS21
{
    class SetSortedLinkedList : SortedList, ISetSorted
    {
        public bool Insert(int x)
        {
            var searchResult = _search_(x);
            if (searchResult.found)
            {
                return false;
            }

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
