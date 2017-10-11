using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            string[] temp = Console.ReadLine().Split(' ');
            Tree tree = new Tree();
            int[] newElementsArray = Array.ConvertAll(temp, Int32.Parse);
            int i = 0;
            int height = 0;
            while (newElementsArray[i] != 0)
            {
               root = tree.UpdateTree(newElementsArray[i], root);
               i++;
            }
            height = tree.GetTreeHeight(root);
            Console.WriteLine("Tree height = " + height);
            Console.ReadLine();
            tree.DepthFirstSearch(root);
        }
        public class Node {
            public int data;
            public Node right;
            public Node left;
        }
        public class Tree
        {
            public Node UpdateTree(int newElement, Node root)
            {
                if (root == null)
                {
                    Node newNode = new Node();
                    newNode.data = newElement;
                    newNode.right = null;
                    newNode.left = null;
                    root = newNode;
                    Console.WriteLine("root " + root.data);
                    Console.ReadLine();
                    return root;
                }
                else if (newElement < root.data)
                {
                    Console.WriteLine("parent " + root.data + " left " + newElement);
                    Console.ReadLine();
                    root.left = UpdateTree(newElement, root.left);
                }
                else if (newElement > root.data)
                {
                    Console.WriteLine("parent " + root.data + " right " + newElement);
                    Console.ReadLine();
                    root.right = UpdateTree(newElement, root.right);
                }
                return root;
            }
            public int GetTreeHeight(Node root)
            {
                if (root == null)
                {
                    return -1;
                }

                int lefth = GetTreeHeight(root.left);
                int righth = GetTreeHeight(root.right);

                if (lefth > righth)
                {
                    return lefth + 1;
                }
                else
                {
                    return righth + 1;
                }
            }
            public void DepthFirstSearch(Node root)
            {
                if (root == null)
                    return;
                DepthFirstSearch(root.left);
                Console.WriteLine(root.data);
                Console.ReadLine();
                DepthFirstSearch(root.right);
            }
        }
    } 
}
