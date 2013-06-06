using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingServices;
using System.IO;

namespace APFTestingHookIn
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> linkedList = new DoubleLinkedList<int>();

            BinaryTree<int> binaryTree = new BinaryTree<int>();
            
            Console.WriteLine("Unsorted Data:");
            Random rand = new Random();
            for (int i = 0; i < 14; ++i)
            {
                int r = rand.Next();
                binaryTree.InsertValue(r);
                linkedList.InsertBack(r);
                Console.WriteLine(r);
            }

            List<int> sortedList = binaryTree.TraverseInOrder();
            binaryTree.BalanceTree();
            List<int> balancedSortedList = binaryTree.TraverseInOrder();

            Console.WriteLine("\nSorted Data from unbalanced tree:");
            for (int i = 0; i < 14; ++i)
            {
                Console.WriteLine(sortedList[i]);
            }

            Console.WriteLine("\nSorted Data from balanced tree:");
            for (int i = 0; i < 14; ++i)
            {
                Console.WriteLine(balancedSortedList[i]);
            }

            Console.WriteLine("\nData from linked list:");
            foreach (int i in linkedList) {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }

    public class MergeSort<T> where T : IComparable
    {
        private List<T> merge(List<T> left, List<T> right)
        {
            List<T> result = new List<T>();

            int leftCounter = 0, rightCounter = 0;
            while (leftCounter < left.Count() || rightCounter < right.Count())
            {
                if (leftCounter < left.Count() && rightCounter < right.Count())
                {
                    if (left[leftCounter].CompareTo(right[rightCounter]) <= 0)
                    {
                        result.Add(left[leftCounter]);
                        ++leftCounter;
                    }
                    else
                    {
                        result.Add(right[rightCounter]);
                        ++rightCounter;
                    }
                }
                else if (leftCounter < left.Count())
                {
                    result.Add(left[leftCounter]);
                    ++leftCounter;
                }
                else
                {
                    result.Add(right[rightCounter]);
                    ++rightCounter;
                }
            }

            return result;
        }

        public List<T> mergeSort(List<T> data)
        {
            if (data.Count() <= 1)
            {
                return data;
            }

            int mid = data.Count() / 2;
            List<T> left, right;

            left = data.GetRange(0, mid);
            right = data.GetRange(mid, data.Count() - mid);

            left = mergeSort(left);
            right = mergeSort(right);

            return merge(left, right);
        }
    }
}
