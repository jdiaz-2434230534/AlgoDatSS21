namespace AlgoDatSS21
{
    class MultiSetSortedLinkedList : SupportList, IMultiSetSorted
    {
        public override bool Insert(int x)
        {
            AddSorted(x);
            return true;
        }
    }
}
