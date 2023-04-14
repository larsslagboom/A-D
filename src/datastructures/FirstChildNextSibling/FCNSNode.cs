namespace AD
{
    public partial class FCNSNode<T> : IFCNSNode<T>
    {
        public FCNSNode<T> firstChild;
        public FCNSNode<T> nextSibling;
        public T data;

        public FCNSNode(T data, FCNSNode<T> firstChild, FCNSNode<T> nextSibling)
        {
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
            this.data = data;
        }

        public FCNSNode(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return data;
        }

        public FCNSNode<T> GetFirstChild()
        {
            return firstChild;
        }

        public FCNSNode<T> GetNextSibling()
        {
            return nextSibling;
        }

        public int Size()
        {
            return 1 + (firstChild?.Size() ?? 0) + (nextSibling?.Size() ?? 0);
        }

        public string PrintChildren()
        {

            return data +
                //first child check
                (firstChild != null ?
                    //second child check  //well next sibling                                  //geen next sibling
                    (nextSibling != null ? ",FC(" + (firstChild?.PrintChildren() ?? "") + ")" : ",FC(" + (firstChild?.PrintChildren() ?? "") + ")")
                    //geen first child
                    : "") +
                    //next sibling check
                    (nextSibling != null ? ",NS(" + (nextSibling?.PrintChildren() ?? "") + ")" : "");
        }
    }
}