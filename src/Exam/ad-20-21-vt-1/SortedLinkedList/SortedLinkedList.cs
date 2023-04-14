using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public partial class SortedLinkedList : ISortedLinkedList
    {
        public SortedLinkedListNode first;
        public SortedLinkedListNode firstSorted;

        public SortedLinkedList()
        {
            first = firstSorted = null;
        }

        public SortedLinkedListNode GetFirst()
        {
            return first;
        }
        public SortedLinkedListNode GetFirstSorted()
        {
            return firstSorted;
        }
        public void AddFirst(int value)
        {
            SortedLinkedListNode node = new SortedLinkedListNode(value);
            if (first != null)
            {
                node.next = first;
                first = node;

                SortedLinkedListNode nodeFirst = first;
                SortedLinkedListNode smallest = first;

                while (nodeFirst.next != null)
                {
                    nodeFirst = nodeFirst.next;
                    if(nodeFirst.data < smallest.data)
                    {
                        smallest = nodeFirst;
                    }
                }

                firstSorted = smallest;

                SortedLinkedListNode nodeFirst2 = first;
                SortedLinkedListNode smallestafter = first;

                while (nodeFirst2.next != null)
                {
                    nodeFirst2 = nodeFirst2.next;
                    if (nodeFirst2.data > node.data && nodeFirst2.data < smallestafter.data)
                    {
                        smallestafter = nodeFirst2;
                    }
                }

                node.nextSorted = smallestafter;

            }
            else
            {
                first = node;
                firstSorted = first;
            }
        }

        public SortedLinkedListNode Find(int data)
        {
            SortedLinkedListNode node = firstSorted;

            if(node == null)
            {
                return null;
            }

            if(node.data == data)
            {
                return node;
            }

            while (node.nextSorted != null)
            {
                node = node.nextSorted;
                if(node.data == data)
                {
                    return node;
                }
            }

            return null;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            SortedLinkedListNode node = first;

            if(node == null)
            {
                return "NULL";
            }

            sb.Append(node.data + " ");

            while (node.next != null)
            {
                node = node.next;
                sb.Append("-> " + node.data);
            }

            return sb.ToString();
        }

        public string ToStringSorted()
        {
            StringBuilder sb = new StringBuilder();
            SortedLinkedListNode node = firstSorted;

            if (node == null)
            {
                return "[]";
            }

            sb.Append("[ " + node.data);

            while (node.nextSorted != null)
            {
                node = node.nextSorted;
                sb.Append(", " + node.data);
            }

            sb.Append(" ]");

            return sb.ToString();
        }
    }
}
