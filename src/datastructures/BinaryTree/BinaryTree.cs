using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Cunstructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = new BinaryNode<T>();
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T>();
            root.data = rootItem;
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return (root.data.Equals((T)default)) ? null : root;
        }

        public int Size()
        {

            if (root.data.Equals((T)default)) return 0;

            return 1 + (root.left?.GetSize() ?? 0) + (root.right?.GetSize() ?? 0);
        }

        public int Height()
        {
            if (root.data.Equals((T)default)) return -1;

            return Math.Max((root.left?.GetHeight() ?? 0), (root.right?.GetHeight() ?? 0));
        }

        public void MakeEmpty()
        {
            root = new BinaryNode<T>();
        }

        public bool IsEmpty()
        {
            return (root.data.Equals((T)default)) ? true : false;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            root = new BinaryNode<T>(rootItem, t1.root, t2.root);
        }

        public string ToPrefixString()
        {
            if (root.data.Equals((T)default)) return "NIL";

            return "[ " + root.data + " [ " + (root.left?.ToPrefixString() ?? "NIL") + " ] [ " + (root.right?.ToPrefixString() ?? "NIL") + " ] ]";
        }

        public string ToInfixString()
        {
            if (root.data.Equals((T)default)) return "NIL";

            return "[ " + ((root.left != null) ? "[ " + (root.left?.ToInfixString() ?? "NIL") + " ]" : (root.left?.ToInfixString() ?? "NIL")) + " " + root.data +
                ((root.right != null) ? " [ " + (root.right?.ToInfixString() ?? "NIL") + " ]" : (root.right?.ToInfixString() ?? " NIL")) + " ]";
        }

        public string ToPostfixString()
        {
            if (root.data.Equals((T)default)) return "NIL";

            return "[ [ " + (root.left?.ToPostfixString() ?? "NIL") + $" ] [ " + (root.right?.ToPostfixString() ?? "NIL") + " ] " + root.data + " ]";
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {

            if (root.data.Equals((T)default)) return 0;

            return (root.left?.NumberOfLeaves() ?? 0) + (root.right?.NumberOfLeaves() ?? 0);
        }

        public int NumberOfNodesWithOneChild()
        {
            if (root.data.Equals((T)default)) return 0;

            return (root.left == null && root.right != null || root.left != null && root.right == null ? 1 : 0) + (root.left?.NumberOfNodesWithOneChild() ?? 0) + (root.right?.NumberOfNodesWithOneChild() ?? 0);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            if (root.data.Equals((T)default)) return 0;

            return (root.left != null && root.right != null ? 1 : 0) + (root.left?.NumberOfNodesWithTwoChildren() ?? 0) + (root.right?.NumberOfNodesWithTwoChildren() ?? 0);
        }
    }
}