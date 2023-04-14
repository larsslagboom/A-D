using System.Collections.Generic;
using System.Linq;

namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            MergeSorts(list, 0, list.Count - 1);
        }

        public void MergeSorts(List<int> list,int left, int right)
        {
            if(left < right)
            {
                int center = (left + right) / 2;
                MergeSorts(list, left, center);
                MergeSorts(list, center+1, right);
                Merge(list,left,center,right);
            }
        }

        public void Merge(List<int> list,int left,int center,int right)
        {
            int n1 = center - left + 1;
            int n2 = right - center;

            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            for (int i = 0; i < n1; i++)
                leftList.Add(list[left + i]);
            for (int j = 0; j < n2; j++)
                rightList.Add(list[center + 1 + j]);

            int leftIndex = 0, rightIndex = 0;

            int k = left;

            while (leftIndex < n1 && rightIndex < n2)
            {
                if (leftList[leftIndex] <= rightList[rightIndex])
                {
                    list[k] = leftList[leftIndex];
                    leftIndex++;
                }
                else
                {
                    list[k] = rightList[rightIndex];
                    rightIndex++;
                }
                k++;
            }

            while (leftIndex < n1)
            {
                list[k] = leftList[leftIndex];
                leftIndex++;
                k++;
            }

            while (rightIndex < n2)
            {
                list[k] = rightList[rightIndex];
                rightIndex++;
                k++;
            }
        }

    }
}
