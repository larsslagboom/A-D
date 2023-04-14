using System;
using System.Collections.Specialized;

namespace AD
{
    public class MIBTree : BinarySearchTree<MIBNode>
    {
        public MIBTree()
        {
            Insert(new MIBNode("1.3.6.1.4.1.9", "cisco"));
            Insert(new MIBNode("1.3.6.1.1.1.1", "system"));
            Insert(new MIBNode("1.3.6", "dod"));
            Insert(new MIBNode("1.3.6.1.1.1.4", "ip"));
            Insert(new MIBNode("1.3.6.1.3", "experimental"));
            Insert(new MIBNode("1.3.6.1.4.1", "enterprise"));
            Insert(new MIBNode("1.3.6.1.1.1.2", "interfaces"));
            Insert(new MIBNode("1.3.6.1.1", "directory"));
            Insert(new MIBNode("1.3", "org"));
            Insert(new MIBNode("1.3.6.1.4.1.2636", "juniperMIB"));
            Insert(new MIBNode("1.3.6.1.4.1.311", "microsoft"));
            Insert(new MIBNode("1.3.6.1", "internet"));
            Insert(new MIBNode("1", "iso"));
            Insert(new MIBNode("1.3.6.1.4", "private"));
            Insert(new MIBNode("1.3.6.1.1.1", "mib-2"));
            Insert(new MIBNode("1.3.6.1.2", "mgmt"));
        }

        public MIBNode FindNode(string oid)
        {

            if (root.data.Equals(default)) throw new BinarySearchTreeEmptyException();

            BinaryNode<MIBNode> parent = root;
            MIBNode mIBNode = null;

            while (mIBNode == null)
            {
                if(oid.CompareTo(parent.data.oid) == 0)
                {
                    mIBNode = parent.data;
                }
                else if(parent.left != null && oid.CompareTo(parent.data.oid) < 0)
                {
                    parent = parent.left;
                }
                else if (parent.right != null && oid.CompareTo(parent.data.oid) > 0)
                {
                    parent = parent.right;
                }
                else
                {
                    break;
                }
            }

            return mIBNode;
        }

        public bool AllNodesAvailable(string oid)
        {

            if(FindNode(oid) != null)
            {
                string[] array = oid.Split(".");

                if(array.Length == 1)
                {
                    return true;
                }
                Array.Resize(ref array, array.Length-1);
                return AllNodesAvailable(string.Join(".", array));
            }
            else
            {
                return false;
            }
            
        }
    }
}
