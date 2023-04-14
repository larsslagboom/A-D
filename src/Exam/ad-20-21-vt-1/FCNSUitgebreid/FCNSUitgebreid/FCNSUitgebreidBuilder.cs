namespace AD
{
    public partial class DSBuilder
    {
        public static IFirstChildNextSibling<int> CreateFirstChildNextSibling_Practicum()
        {
            FirstChildNextSibling<int> tree = new FirstChildNextSibling<int>();

            FCNSNode<int> acht = new FCNSNode<int>(8, null, null);
            FCNSNode<int> zeven = new FCNSNode<int>(7, null, acht);
            FCNSNode<int> zes = new FCNSNode<int>(6, null, zeven);
            FCNSNode<int> vier = new FCNSNode<int>(4, zes, null);
            FCNSNode<int> drie = new FCNSNode<int>(3, null, vier);
            FCNSNode<int> vijf = new FCNSNode<int>(5, null, null);
            FCNSNode<int> twee = new FCNSNode<int>(2, vijf, drie);
            FCNSNode<int> een = new FCNSNode<int>(1, twee, null);

            tree.root = een;

            return tree;
        }
    }
}
