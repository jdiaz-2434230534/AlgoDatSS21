namespace AlgoDatSS21
{
    class MultiSetUnsortedLinkedList : UnsortedList, IMultiSetUnsorted
    {
        public bool Insert(int x)
        {
            var searchResult = _search_(x);
            
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
