using System;

namespace AlgoDatSS21
{
  class SetSortedArray : SortedArray, ISetSorted
  {
    public bool Insert(int x)
    {
      if (Search(x))
      {
        return false;
      }
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
          newEntries[i] = entries[i - 1];
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
