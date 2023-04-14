using System;
using System.Collections.Generic;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FCNSNode<T> root;

        public int Size()
        {
            if (root != null)
            {
                return root.Size();
            }
            else
            {
                return 0;
            }
        }

        public void PrintPreOrder()
        {
            int spaces = 0;
            bool searching = true;
            FCNSNode<T> pointer = root;
            List<FCNSNode<T>> lastPointerList = new List<FCNSNode<T>>();
            if (pointer == null)
            {
                Console.WriteLine("NIL");
            }
            else
            {
                Console.WriteLine(pointer.data.ToString());

                while (searching)
                {
                    if (pointer.GetFirstChild() != null)
                    {
                        spaces++;
                        if (pointer.GetNextSibling() != null)
                        {
                            FCNSNode<T> node = pointer;
                            lastPointerList.Add(node);
                        }
                        string data = "";
                        for (int i = 0; i < spaces; i++)
                        {
                            data += "  ";
                        }
                        data += pointer.GetFirstChild().GetData().ToString();
                        Console.WriteLine(data);
                        pointer = pointer.GetFirstChild();
                    }
                    else if (pointer.GetNextSibling() != null)
                    {
                        string data = "";
                        for (int i = 0; i < spaces; i++)
                        {
                            data += "  ";
                        }
                        data += pointer.GetNextSibling().GetData().ToString();
                        Console.WriteLine(data);
                        pointer = pointer.GetNextSibling();
                    }
                    else
                    {
                        if (lastPointerList.Count > 0)
                        {
                            spaces--;
                            pointer = lastPointerList[lastPointerList.Count - 1].GetNextSibling();
                            string data = "";
                            for (int i = 0; i < spaces; i++)
                            {
                                data += "  ";
                            }
                            data += pointer.GetData().ToString();
                            Console.WriteLine(data);
                            lastPointerList.RemoveAt(lastPointerList.Count - 1);
                        }
                        else
                        {
                            searching = false;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            if (root != null)
            {
                return root.PrintChildren();
            }
            else
            {
                return "NIL";
            }
        }

    }
}