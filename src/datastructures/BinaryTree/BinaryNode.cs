using System;
using System.ComponentModel.DataAnnotations;

namespace AD
{
    public partial class BinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default(T), default(BinaryNode<T>), default(BinaryNode<T>)) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public int GetSize()
        {
            return 1 + (left?.GetSize() ?? 0) + (right?.GetSize() ?? 0);
        }

        public int GetHeight()
        {
            return 1 + Math.Max((left?.GetHeight() ?? 0), (right?.GetHeight() ?? 0));
        }

        public string ToPrefixString()
        {
            return data + ((left != null) ? " [ " + (left?.ToPrefixString() ?? "NIL") + " ]" : (left?.ToPrefixString() ?? " NIL")) +
                ((right != null) ? " [ " + (right?.ToPrefixString() ?? "NIL") + " ]" : (right?.ToPrefixString() ?? " NIL"));
        }

        public string ToInfixString()
        {
            return ((left != null) ? "[ " + (left?.ToInfixString() ?? "NIL") + " ]" : (left?.ToInfixString() ?? "NIL")) + " " + data +
                ((right != null) ? " [ " + (right?.ToInfixString() ?? "NIL") + " ]" : (right?.ToInfixString() ?? " NIL"));
        }

        public string ToPostfixString()
        {
            return ((left != null) ? "[ " + (left?.ToPostfixString() ?? "NIL") + " ]" : (left?.ToPostfixString() ?? "NIL")) +
                ((right != null) ? " [ " + (right?.ToPostfixString() ?? "NIL") + " ]" : (right?.ToPostfixString() ?? " NIL")) + " " + data;
        }

        public int NumberOfLeaves()
        {
            return (left == null && right == null) ? 1 : (left?.NumberOfLeaves() ?? 0) + (right?.NumberOfLeaves() ?? 0);
        }

        public int NumberOfNodesWithOneChild()
        {
            return (left == null && right != null || left != null && right == null) ? 1 : (left?.NumberOfNodesWithOneChild() ?? 0) + (right?.NumberOfNodesWithOneChild() ?? 0);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            return (left != null && right != null) ? 1 : (left?.NumberOfNodesWithTwoChildren() ?? 0) + (right?.NumberOfNodesWithTwoChildren() ?? 0);
        }

        public T FindMin()
        {
            return (left == null) ? data : left.FindMin();
        }

        public void RemoveMin()
        {
            if (left.left == null && left.right == null)
            {
                left = null;
            }
            else if (left.left == null && left.right != null)
            {
                left = left.right;
            }
            else
            {
                left.RemoveMin();
            }
        }

        public string InOrder()
        {
            return (left?.InOrder() ?? "") + data + " " + (right?.InOrder() ?? "");
        }
    }
}