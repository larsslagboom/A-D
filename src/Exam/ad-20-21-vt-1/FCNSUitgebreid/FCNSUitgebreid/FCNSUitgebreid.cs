using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public IFCNSNode<T> FindParent(T data)
        {
            // Je mag aannemen dat "data" in de boom zit en uniek is
            if (root.data.Equals(data)) return null;
            
            FCNSNode<T> parent = root;
            List<FCNSNode<T>> parentsWithChild = new List<FCNSNode<T>>();

            parentsWithChild.Add(root.firstChild);

            while (parentsWithChild.Count > 0)
            {
                FCNSNode<T> node = parent.firstChild;
                parentsWithChild.Remove(parent);

                bool noNextSibling = true;

                while (noNextSibling)
                {
                    if(node.GetFirstChild() != null)
                    {
                        parentsWithChild.Add(node);
                    }

                    if(node.GetData().Equals(data))
                    {
                        return parent;
                    }
                    else
                    {
                        if(node.GetNextSibling() != null)
                        {
                            node = node.nextSibling;
                        }
                        else
                        {
                            noNextSibling = false;
                        }
                    }
                }

                parent = parentsWithChild.First();
            }

            return parent;
        }

        public string SiblingsToString(T data)
        {
            StringBuilder sb = new StringBuilder();

            IFCNSNode<T> parent= FindParent(data);

            sb.Append($"Siblings of {data}:");

            if (parent == null)
            {
                return sb.ToString();
            }

            IFCNSNode<T> parentFirstChild = parent.GetFirstChild();

            bool noNextSibling = true;

            while (noNextSibling)
            {
                if (!parentFirstChild.GetData().Equals(data))
                {
                    sb.Append(" " + parentFirstChild.GetData());
                }
                if(parentFirstChild.GetNextSibling() != null)
                {
                    parentFirstChild = parentFirstChild.GetNextSibling();
                }
                else
                {
                    noNextSibling = false;
                }
            }

            return sb.ToString();
        }
    }

}