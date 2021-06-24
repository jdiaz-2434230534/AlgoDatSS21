

namespace AlgoDatSS21
{
  class MultiSetSortedArray : SortedArray, IMultiSetSorted
  {
    public bool Insert(int x)
    {
      int newIndex = 0;
      while (newIndex < entries.Length && entries[newIndex] < x)
      {
        newIndex++;
      }
      var newEntries = new int[entries.Length + 1];
      for (int i = 0; i < newEntries.Length; i++)
      {
        if (i < newIndex)
        {
          newEntries[i] = entries[i];
        } else if (i > newIndex)
        {
          newEntries[i] = entries[i + 1];
        } else if (i == newIndex)
        {
          newEntries[i] = x;
        }
      }

      entries = newEntries;
      return true;
    }
  }
}
