namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IBinaryTree<int> CreateBinaryTreeEmpty()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            return tree;
        }

        //
        //         5
        //       /   \
        //     2       6
        //    / \
        //   8   7
        //      /
        //     1
        //
        public static IBinaryTree<int> CreateBinaryTreeInt()
        {
            BinaryTree<int> i55 = new BinaryTree<int>();

            BinaryNode<int> i6 = new BinaryNode<int>(6, null, null);
            BinaryNode<int> i1 = new BinaryNode<int>(1, null, null);
            BinaryNode<int> i7 = new BinaryNode<int>(7, i1, null);
            BinaryNode<int> i8 = new BinaryNode<int>(8, null, null);
            BinaryNode<int> i2 = new BinaryNode<int>(2, i8, i7);
            BinaryNode<int> i5 = new BinaryNode<int>(5, i2, i6);

            i55.root = i5;

            return i55;
        }

        //
        //         t
        //       /   \
        //     w       a
        //    / \     / \
        //   q   g   o   p
        public static IBinaryTree<string> CreateBinaryTreeString()
        {
            BinaryTree<string> tq = new BinaryTree<string>("q");
            BinaryTree<string> tg = new BinaryTree<string>("g");
            BinaryTree<string> to = new BinaryTree<string>("o");
            BinaryTree<string> tp = new BinaryTree<string>("p");
            BinaryTree<string> tw = new BinaryTree<string>();
            BinaryTree<string> tt = new BinaryTree<string>();
            BinaryTree<string> ta = new BinaryTree<string>();

            tw.Merge("w", tq, tg);
            ta.Merge("a", to, tp);
            tt.Merge("t", tw, ta);

            return tt;
        }
    }
}