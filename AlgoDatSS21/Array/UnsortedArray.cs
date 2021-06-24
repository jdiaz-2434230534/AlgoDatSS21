namespace AlgoDatSS21
{
    public abstract class UnsortedArray: Array
    {
        protected override int _search_(int elem)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] == elem)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}