using System;

namespace AlgoDatSS21
{
    public abstract class List
    {
        protected ListEntry root = null;

        protected abstract ListSearchResult _search_(int elem);

        public bool Search(int elem)
        {
            return _search_(elem).found;
        }

        public bool Delete(int elem)
        {
            var searchResult = _search_(elem);
            if (!searchResult.found)
            {
                return false;
            }

            // Result is root
            if (searchResult.lastEntry == null)
            {
                root = root.next;
                return true;
            }
            // remove node from list
            searchResult.lastEntry.next = searchResult.lastEntry.next.next;
            return true;
        }
        
        public void Print()
        {
            var str = "";
            var current = root;
            while (current != null)
            {
                str += current.value + " ";
                current = current.next;
            }
            Console.WriteLine(str);
        }
    }

    public class ListEntry
    {
        public int value;
        public ListEntry next;

        public ListEntry(int value)
        {
            this.value = value;
            next = null;
        }
        
        public ListEntry(int value, ListEntry next)
        {
            this.value = value;
            this.next = next;
        }
    }

    public class ListSearchResult
    {
        public bool found;
        public ListEntry lastEntry;

        public ListSearchResult(bool found, ListEntry lastEntry)
        {
            this.found = found;
            this.lastEntry = lastEntry;
        }
    }
}
