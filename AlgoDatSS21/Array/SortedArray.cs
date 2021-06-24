namespace AlgoDatSS21
{
    public abstract class SortedArray: Array
    {
        protected override int _search_(int elem)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                if (entry == elem)
                {
                    return i;
                }

                // If entry is bigger, elem is not in array -> Sorted
                if (entry > elem)
                {
                    return -1;
                }
            }
            return -1;
        }
    }
}