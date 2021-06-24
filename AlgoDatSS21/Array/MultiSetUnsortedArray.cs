using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS21
{
  class MultiSetUnsortedArray : UnsortedArray, IMultiSetUnsorted
  {
    public bool Insert(int x)
    {
      entries = entries.Concat(new[] {x}).ToArray();
      return true;
    }
  }
}

