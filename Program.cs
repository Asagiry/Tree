using System;



namespace Tree
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public int value { get; set; }
        public int balance { get; set; }
        public TreeNode(int key)
        {
            this.value = key;
            this.balance = 0;
            this.left = null;
            this.right = null;
        }
        public TreeNode()
        {
            this.value = 0;
            this.balance = 0;
            this.left = null;
            this.right = null;
        }

    }
    public static class Program
    {
        public static TreeNode root;


        static void Main(string[] args)
        {
            Console.WriteLine("Введите корень");
            insertNode(root, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Введите 3 элемента");
            insertNode(root, Convert.ToInt32(Console.ReadLine()));
            insertNode(root, Convert.ToInt32(Console.ReadLine()));
            insertNode(root, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();
            setBalance(root);
            DisplayIndented(root);
        }

        public static void insertNode(TreeNode root, int key)
        {
            TreeNode newNode = new TreeNode(key);
            if (root == null)
            {
                Program.root = newNode;
                return;
            }
            TreeNode F = searchNode(key);
            if (F.value > key)
            {
                F.left = newNode;
            }
            if (F.value < key)
            {
                F.right = newNode;
            }
        }
        public static TreeNode searchNode(int key)
        {
            TreeNode T = Program.root;
            TreeNode F = T;
            while (T != null)
            {
                if (T.value == key)
                {
                    return F;
                }
                F = T;
                if (T.value > key)
                {
                    T = T.left;
                    continue;
                }
                if (T.value < key)
                {
                    T = T.right;
                    continue;
                }
            }
            return F;
        }
        public static void setBalance(TreeNode root)
        {
            if (root.left != null)
            {
                root.balance = height(root.left) - height(root.right);
                setBalance(root.left);
            }
            if (root.right != null)
            {
                root.balance = height(root.left) - height(root.right);
                setBalance(root.right);
            }
            if ((root.right == null) && (root.left == null))
            {
                root.balance = 0;
            }
        }
        public static int height(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + ((height(node.left) > height(node.right)) ? height(node.left) : height(node.right));
        }
        public static void DisplayIndented(TreeNode root, int level = 0)
        {
            if (root != null)
            {
                DisplayIndented(root.right, level + 1);
                Console.WriteLine($"{new string(' ', level * 2)}{root.value}({root.balance})");
                DisplayIndented(root.left, level + 1);
            }
        }
    }

}
