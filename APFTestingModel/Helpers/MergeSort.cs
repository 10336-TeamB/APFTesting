using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
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
