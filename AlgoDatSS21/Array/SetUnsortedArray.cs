using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS21
{
  class SetUnsortedArray : UnsortedArray, ISetUnsorted
  {
    public bool Insert(int x)
    {
      if (Search(x))
      {
        return false;
      }

      entries = entries.Concat(new[] {x}).ToArray();
      return true;
    }
  }
}
