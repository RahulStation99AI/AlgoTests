
namespace Alogs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;

    /*
     Problem Description: 
    Implement a BST (Binary Search Tree) with the following features:
        Insert 
        Delete
        GetRandom() - returns a random node or value of the random node.
        Start with GetRandom()
     
     */
    public class BSTTreeNode
    {
        ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        public int Val;
        public BSTTreeNode Left;
        public BSTTreeNode Right;
        public BSTTreeNode(int val)
        {
            Val = val;
            Left = null;
            Right = null;
        }
    }
    public  class BST
    {
        public BSTTreeNode Root;
        public int NumOfNodes;
        public BSTTreeNode AddNode(int value)
        {
            var newNode = new BSTTreeNode(value);
            
           if(Root == null)
            {
                Root = newNode;
                NumOfNodes++;
                return Root;
            }

           var currentNode = Root;
           BSTTreeNode parent = currentNode;

            while(currentNode != null)
            {
                parent = currentNode;
                if (currentNode.Val < value)
                { 
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }

            if(parent?.Val < value)
            {
                parent.Right = newNode;
            }
            else
            {
                parent.Left = newNode;
            }

            NumOfNodes++;

            return newNode;
        }

        // Delete Node Practice.
        public BSTTreeNode DeleteNode(int value)
        {
            if (this.Root == null) return null;

            BSTTreeNode currentNode = this.Root;
            BSTTreeNode parentNode = null;

            // Find the node with the given value
            while (currentNode != null && currentNode.Val != value)
            {
                parentNode = currentNode;
                if (value < currentNode.Val)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            if (currentNode == null) return null; // Node not found.

            // Case 1: Node to be deleted has no children (leaf node).
            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (parentNode == null)
                {
                    this.Root = null; // Tree had only one node.
                }
                else if (parentNode.Left == currentNode)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }
            }

            // Case 2: Node to be deleted has one child.
            else if (currentNode.Left == null || currentNode.Right == null)
            {
                BSTTreeNode childNode = currentNode.Left ?? currentNode.Right;
                if (parentNode == null)
                {
                    this.Root = childNode; // Node to be deleted is root.
                }
                else if (parentNode.Left == currentNode)
                {
                    parentNode.Left = childNode;
                }
                else
                {
                    parentNode.Right = childNode;
                }
            }

           // Case 3: Node to be deleted has two children.
            else
            {
                // Find the inorder successor (smallest in the right subtree).
                BSTTreeNode successorParent = currentNode;
                BSTTreeNode successor = currentNode.Right;
                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }
                // Replace currentNode's value with successor's value.
                currentNode.Val = successor.Val;
                // Delete the successor node.
                if (successorParent.Left == successor)
                {
                    successorParent.Left = successor.Right;
                }
                else
                {
                    successorParent.Right = successor.Right;
                }
            }

            NumOfNodes--;
            return currentNode;
        }

        public  BSTTreeNode GetRandomNode()
        {
            int randomdIndexInTree = new Random().Next(1, NumOfNodes);
            Console.WriteLine($"RandomIndex : {randomdIndexInTree}");

            return BSFToIndex(randomdIndexInTree, Root);

        }


        BSTTreeNode BSFToIndex(int indexIntree, BSTTreeNode root)
        {   
           if (indexIntree > NumOfNodes) return null;

            var nodeList = new Queue<BSTTreeNode>();

            nodeList.Enqueue(root);

            int count =1;
            BSTTreeNode curNode = null;

            while (nodeList.Count > 0)
            {
                curNode = nodeList.Dequeue();
                
                if(count == indexIntree)
                {
                    break;
                }
                if(curNode.Left != null)
                {
                    nodeList.Enqueue(curNode.Left);
                }
                if(curNode.Right != null)
                {
                    nodeList.Enqueue(curNode.Right);
                }
                count++;
            }

            Console.WriteLine($"Random Index: {indexIntree}, value: {curNode.Val}");
            return curNode;
        }
        
        public void PrintNodesDFS(BSTTreeNode root)
        {
            if(root == null)
            {
                return;
            }
            Console.WriteLine($" Node Value : {root.Val}");
            PrintNodesDFS(root.Left);
            PrintNodesDFS(root.Right);
        }

        public void PrintNodesBFS(BSTTreeNode root)
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BSTTreeNode>();
            var node = root;
            while (node != null)
            {
                Console.WriteLine($" Node Value : {node.Val}");
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
                if (queue.Count != 0)
                {
                    node = queue.Dequeue();
                }
                else
                {
                    node = null;
                }
            }
        }
        private BSTTreeNode DFSToIndex(int randomdIndexInTree, BSTTreeNode root)
        {   
            var nodeList = new Stack<BSTTreeNode>();
            int count = 0;

            var curNode = root;

            while(count < randomdIndexInTree) // total node 20. randomdIndexInTree  1-20  
            {
                nodeList.Push(curNode);
                count++;
                if (count == randomdIndexInTree)
                {
                    break;
                }

                
                if(curNode.Left != null)
                {
                    nodeList.Push(curNode.Left);
                    count++;
                }

                if(count == randomdIndexInTree)
                {
                    break;
                }
                
                if(root.Right != null)
                {
                    nodeList.Push(curNode.Right);
                    count++;
                }
                
                if (count == randomdIndexInTree)
                {
                    break;
                }

                curNode = nodeList.Pop();
            }
            
            return nodeList.Pop();
        }

        public class SanjibCodingTest
        {

            /*
                    Desription: 

                    Error Cases:

                    Edge Case:

                    Algo:

                    Steps:



                    Error Handling:

           */
        }

        public static void Test()
        {
            int[] nodes = { 7, 5, 6, 1,8, 3, 4, 10, 12,11 };
            var binarySearchTree = new BST();

            foreach(int nodeValue in nodes)
            {
                binarySearchTree.AddNode(nodeValue);
            }
            Console.WriteLine("DFS tree");
            binarySearchTree.PrintNodesDFS(binarySearchTree.Root);
            Console.WriteLine("BFS tree");
            binarySearchTree.PrintNodesBFS(binarySearchTree.Root);

            var node = binarySearchTree.GetRandomNode();

            binarySearchTree.DeleteNode(8);
            Console.WriteLine("After Deletion of 8");
            Console.WriteLine("BFS tree");
            binarySearchTree.PrintNodesBFS(binarySearchTree.Root);

            binarySearchTree.DeleteNode(7);
            Console.WriteLine("After Deletion of 7");
            Console.WriteLine("BFS tree");
            binarySearchTree.PrintNodesBFS(binarySearchTree.Root);

            binarySearchTree.DeleteNode(4);
            Console.WriteLine("After Deletion of 4");
            Console.WriteLine("BFS tree");
            binarySearchTree.PrintNodesBFS(binarySearchTree.Root);

            Console.WriteLine($"No of Nodes: {binarySearchTree.NumOfNodes}");
        }
    }
}