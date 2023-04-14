namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Insert(T x)
        {

            if (root.data == null)
            {
                root.data = x;
            }
            else
            {
                BinaryNode<T> parent = new BinaryNode<T>();
                var ptr = root;

                while (ptr != null)
                {
                    parent = ptr;

                    if (x.CompareTo(ptr.data) < 0)
                    {
                        ptr = ptr.left;
                    }
                    else
                    {
                        ptr = ptr.right;
                    }
                }

                if (parent == null)
                {
                    root.data = x;
                }
                else if (x.CompareTo(parent.data) < 0)
                {
                    parent.left = new BinaryNode<T>();
                    parent.left.data = x;
                }
                else
                {
                    parent.right = new BinaryNode<T>();
                    parent.right.data = x;
                }
            }
        }

        public T FindMin()
        {
            if (root.data.Equals((T)default)) throw new BinarySearchTreeEmptyException();

            return (root.left == null) ? root.data : root.left.FindMin();
        }

        public void RemoveMin()
        {
            if (root.data.Equals((T)default)) throw new BinarySearchTreeEmptyException();

            if (root.left != null)
            {
                if(root.left.left == null && root.left.right == null)
                {
                    root.left = null;
                }else if (root.left.left == null && root.left.right != null)
                {
                    root.left = root.left.right;
                }
                else
                {
                    root.left.RemoveMin();
                }
            }
            else
            {
                root.data = default;
            }
        }

        public void Remove(T x)
        {
            if (root.data.Equals((T)default)) throw new BinarySearchTreeElementNotFoundException();

            BinaryNode<T> parent = new BinaryNode<T>();
            BinaryNode<T> parentParent = new BinaryNode<T>();
            var ptr = root;

            while (ptr != null)
            {
                if (parent != null) parentParent = parent;
                parent = ptr;

                if (x.CompareTo(ptr.data) < 0)
                {
                    if(ptr.left == null)
                    {
                        throw new BinarySearchTreeElementNotFoundException();
                    }
                    ptr = ptr.left;
                }
                else if (x.CompareTo(ptr.data) > 0)
                {
                    if (ptr.right == null)
                    {
                        throw new BinarySearchTreeElementNotFoundException();
                    }
                    ptr = ptr.right;
                }
                else
                {
                    //left and right are empty
                    if (parent.left == null && parent.right == null)
                    {
                        if (parentParent != null)
                        {
                            //check if it was left or right from upperParent
                            if (x.CompareTo(parentParent.data) < 0)
                            {
                                //left
                                parentParent.left = null;
                            }
                            else
                            {
                                //right
                                parentParent.right = null;
                            }
                        }
                        else
                        {
                            parent.data = default;
                        }
                    }
                    //left not empty right is empty
                    else if(parent.left != null && parent.right == null)
                    {
                        if (parentParent != null)
                        {
                            //check if it was left or right from upperParent
                            if (x.CompareTo(parentParent.data) < 0)
                            {
                                //left
                                parentParent.left = parent.left;
                            }
                            else
                            {
                                //right
                                parentParent.right = parent.left; ;
                            }
                        }
                        else
                        {
                            root = parent.left;
                        }
                    }
                    //left is empty right not empty
                    else if (parent.left == null && parent.right != null)
                    {
                        if (parentParent != null)
                        {
                            //check if it was left or right from upperParent
                            if (x.CompareTo(parentParent.data) < 0)
                            {
                                //left
                                parentParent.left = parent.right;
                            }
                            else
                            {
                                //right
                                parentParent.right = parent.right; ;
                            }
                        }
                        else
                        {
                            root = parent.right;
                        }
                    }
                    //both not empty
                    else
                    {
                        BinaryNode<T> newParent = SearchMinNoLeft(parent.right);
                        parent.data = newParent.data;
                        if (parentParent != null)
                        {
                            //check if it was left or right from upperParent
                            if (x.CompareTo(parentParent.data) < 0)
                            {
                                //left
                                parentParent.left = newParent.right;
                            }
                            else
                            {
                                //right
                                parentParent.right = newParent.right;
                            }
                        }
                        else
                        {
                            root = newParent.right;
                        }
                    }
                    ptr = null;
                }
            }
        }

        public BinaryNode<T> SearchMinNoLeft(BinaryNode<T> parent)
        {
            while (parent.left != null)
            {
                parent = parent.left;
            }
            return parent;
        }

        public string InOrder()
        {

            if (root.data.Equals((T)default)) return "";

            return (root.left?.InOrder() ?? "") + root.data + " " + (root.right?.InOrder() ?? "");

        }

        public override string ToString()
        {
            if (root.data.Equals((T)default)) return "";

            return InOrder().Substring(0, InOrder().Length-1);
        }
    }
}
