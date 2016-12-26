using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBitTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            this.val = x; this.left = this.right = null;
        }

        public void Inorder(TreeNode node)
        {
            Stack<TreeNode> orderStack = new Stack<TreeNode>();
            TreeNode poppedNode;

            while (node != null)
            {
                orderStack.Push(node);
                node = node.left;
            }

            while (orderStack.Count > 0)
            {
                poppedNode = orderStack.Pop();
                Console.WriteLine(poppedNode.val);
                node = poppedNode;

                if (node.right != null)
                {
                    node = node.right;
                    while (node != null)
                    {
                        orderStack.Push(node);
                        node = node.left;
                    }
                }
            }
        }

        public void PreOrder(TreeNode node)
        {
            Stack<TreeNode> orderStack = new Stack<TreeNode>();
            TreeNode poppedNode;

            orderStack.Push(node);

            while (orderStack.Count > 0)
            {
                poppedNode = orderStack.Pop();
                Console.WriteLine(poppedNode.val);

                if (poppedNode.right != null)
                {
                    orderStack.Push(poppedNode.right);
                }

                if (poppedNode.left != null)
                {
                    orderStack.Push(poppedNode.left);
                }
            }
        }

        public void PostOrder(TreeNode node)
        {
            Stack<int> order = new Stack<int>();
            Stack<TreeNode> orderStack = new Stack<TreeNode>();
            TreeNode poppedNode;
            orderStack.Push(node);

            while (orderStack.Count > 0)
            {
                poppedNode = orderStack.Pop();
                order.Push(poppedNode.val);

                if (poppedNode.left != null)
                {
                    orderStack.Push(poppedNode.left);
                }
                if (poppedNode.right != null)
                {
                    orderStack.Push(poppedNode.right);
                }
            }

            foreach (int i in order) {
                Console.WriteLine(i);
            }
        }

        public TreeNode LeastCommonAncestor(TreeNode node, int one, int two, ref bool a, ref bool b) {

            if (node == null) {
                return null;
            }

            if (node.val == two) {
                b = true;
                return node;
            }

            if (node.val == one) {
                a = true;
                return node;
            }

            TreeNode left = LeastCommonAncestor(node.left, one, two, ref a, ref b);
            TreeNode right = LeastCommonAncestor(node.right, one, two, ref a, ref b);

            if (left != null && right != null)
            {
                return node;//fetches the answer
            }


            return left != null ? left : right;
        }

        public int MaxDepth(TreeNode node) {

            if (node == null) {
                return 0;
            }

            return 1 + Math.Max(MaxDepth(node.left), MaxDepth(node.right));
        }

        public int minDepth(TreeNode node) {
            int left = 0, right = 0;

            if (node != null && node.left == null && node.right == null)
                return 1;

            if (node.left != null) {
                left = 1 + minDepth(node.left);
            }

            if (node.right != null) {
                right = 1 + minDepth(node.right);
            }

            if (left == 0 || right == 0) {
                return left > 0 ? left : right;
            }

            if (left >= right)
                return right;

            else
                return left;

        }

        public int minDepth2(TreeNode node, int level) {
            if (node == null)
                return int.MaxValue;

            if (node.left == null && node.right == null)
            {
                return level + 1;
            }

            int left = minDepth2(node.left, level + 1);
            int right = minDepth2(node.right, level + 1);

            return Math.Min(left, right);
        }

        public bool IsBalance(TreeNode node) {
            if (node == null)
                return true;

            if (node.left == null && node.right == null) {
                return true;
            }

            if (node.left == null || node.right == null) {
                return false;
            }

            return IsBalance(node.left) && IsBalance(node.right);
        }

        public int isBalance(TreeNode node) {

            if (node == null) {
                return 0;
            }

            int left = 1 + isBalance(node.left);
            int right = 1 + isBalance(node.right);

            if (Math.Abs(left - right) <= 1 && left != -1 && right != -1)
                return left + right;

            else
                return -1;
        }

        public bool Is_Balance_Tree(TreeNode node) {
            return (Depth(node) == -1) ? false : true; 
        }

        public int Depth(TreeNode root) {
            if (root == null)
                return 0;

            int left = Depth(root.left);
            int right = Depth(root.right);

            if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
                return -1;

            return Math.Max(left, right) + 1;
        }

        public bool IdenticalBinaryTree(TreeNode node1, TreeNode node2) {
            if (node1 == null && node2 ==null) {
                return true;
            }

            if (node1 == null || node2 == null) {
                return false;
            }

            return node1.val == node2.val && IdenticalBinaryTree(node1.left, node2.left) && IdenticalBinaryTree(node1.right, node2.right);
        }

        public bool IsSymetric(TreeNode node) {
            return AreSymetric(node, node);
        }

        public bool AreSymetric(TreeNode node1, TreeNode node2) {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            if (node1 == null || node2 == null)
            {
                return false;
            }

            return node1.val == node2.val && AreSymetric(node1.left, node2.right) && AreSymetric(node1.right, node2.left);
        }
    }
}