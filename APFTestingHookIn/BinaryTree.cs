using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingHookIn
{
    class BinaryTree<T> where T : IComparable
    {
        public class Node
        {
            public T Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node()
            {
                Left = null;
                Right = null;
            }
        }

        Node root = null;

        public void InsertValue(T value) {
            if (root == null)
            {
                root = new Node();
                root.Parent = value;
                return;
            }

            Node iterator = root;

            while (true)
            {
                if (iterator.Parent.CompareTo(value) >= 0)
                {
                    Node left = iterator.Left;
                    if (left == null)
                    {
                        left = new Node();
                        left.Parent = value;
                        iterator.Left = left;
                        break;
                    }
                    iterator = left;
                }
                else
                {
                    Node right = iterator.Right;
                    if (right == null)
                    {
                        right = new Node();
                        right.Parent = value;
                        iterator.Right = right;
                        break;
                    }
                    iterator = right;
                }
            }
        }

        public List<T> TraverseInOrder()
        {
            return inOrder(root);
        }

        private List<T> inOrder(Node node)
        {
            List<T> result = new List<T>();

            if (node != null)
            {
                result = inOrder(node.Left);
                result.Add(node.Parent);
                result.AddRange(inOrder(node.Right));
            }

            return result;
        }

        public void BalanceTree()
        {
            List<T> sortedValues = inOrder(root);

            root = null;
            balancedBulkInsert(sortedValues);
        }

        private void balancedBulkInsert(List<T> sortedValues)
        {
            int numOfItems = sortedValues.Count;
            if (numOfItems == 0)
            {
                return;
            }
            else if (numOfItems == 1)
            {
                InsertValue(sortedValues[0]);
                return;
            }

            int midValueIndex = numOfItems / 2;
            List<T> left, right;
            InsertValue(sortedValues[midValueIndex]);
            left = sortedValues.GetRange(0, midValueIndex);
            right = sortedValues.GetRange(midValueIndex + 1, numOfItems - midValueIndex - 1);

            balancedBulkInsert(left);
            balancedBulkInsert(right);
        }
    }
}
