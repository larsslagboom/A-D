namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_Empty ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();
            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_Small ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();

            FCNSNode<string> d = new FCNSNode<string> ("d");
            FCNSNode<string> c = new FCNSNode<string> ("c");
            FCNSNode<string> b = new FCNSNode<string> ("b", d, c);
            FCNSNode<string> a = new FCNSNode<string> ("a", b, null);

            tree.root = a;

            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_18_3 ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string>();

            FCNSNode<string> k = new FCNSNode<string>("k", null, null);
            FCNSNode<string> j = new FCNSNode<string>("j", k, null);
            FCNSNode<string> i = new FCNSNode<string>("i", null, j);
            FCNSNode<string> e = new FCNSNode<string>("e", i, null);
            FCNSNode<string> h = new FCNSNode<string>("h", null, null);
            FCNSNode<string> d = new FCNSNode<string>("d", h, e);
            FCNSNode<string> c = new FCNSNode<string>("c", null, d);
            FCNSNode<string> g = new FCNSNode<string>("g", null, null);
            FCNSNode<string> f = new FCNSNode<string>("f", null, g);
            FCNSNode<string> b = new FCNSNode<string>("b", f, c);
            FCNSNode<string> a = new FCNSNode<string>("a", b, null);

            tree.root = a;

            return tree;
        }
    }
}