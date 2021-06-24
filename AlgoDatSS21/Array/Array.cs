using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS21
{
  public abstract class Array
  {
    protected int[] entries = new int[0];

    protected abstract int _search_(int elem);

    public bool Search(int elem)
    {
      return _search_(elem) != -1;
    }

    public bool Delete(int elem)
    {
      var indexToDelete = _search_(elem);
      if (indexToDelete == -1)
      {
        // Not found
        return false;
      }
      // Filter Item to delete
      entries = entries.Where((_elem, _index) => _index != indexToDelete).ToArray();
      return true;
    }
    
    //Print Methode, von der alle Array-Klassen erben
    public void Print()
    {
      Console.WriteLine("[{0}]", string.Join(", ", entries));
    }
  }
}
