namespace AlgoDatSS21
{
    class MultiSetUnsortedLinkedList : SupportList, IMultiSet
    {
        public override bool Insert(int x)
        {
            Enque(x);     //als letztes Element einfügen
            return true;
        }
    }
}
