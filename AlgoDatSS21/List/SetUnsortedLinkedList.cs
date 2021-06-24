namespace AlgoDatSS21
{
    class SetUnsortedLinkedList : UnsortedList, ISetUnsorted
    {
        public bool Insert(int x)
        {
            var searchResult = _search_(x);

            // Already in List
            if (searchResult.found)
            {
                return false;
            }
            
            // Position is root
            if (searchResult.lastEntry == null)
            {
                root = new ListEntry(x);
                return true;
            }
            
            searchResult.lastEntry.next = new ListEntry(x);
            return true;
        }
    }
}
