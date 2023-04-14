using System.Collections.Generic;


namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        public override void Sort(List<int> list)
        {
            // Should be implemented in lecture 4!
            throw new System.NotImplementedException();
        }

        static void QuickSorter(List<int> input, int left, int right)
        {
            int center = (left + right) / 2;
            if ((right - left + 1) > CUTOFF)
            {
                QuickSortAlgo(input, left, right);
                QuickSorter(input, left, center);
                QuickSorter(input, center + 1, right);
            }

        }

        static void QuickSortAlgo(List<int> input, int left, int right)
        {
            int middle = input[(left + right) / 2];
            int pivot = 0;
            int first = input[left];
            int last = input[right];
            if ((first > last && first < middle) || first < last && first > middle)
            {
                pivot = first;
                var temp = input[right];
                input[right] = pivot;
                input[left] = temp;
            }
            else if ((last > first && last < middle) || last < first && last > middle)
            {
                pivot = last;
            }
            else if ((middle > first && middle < last) || middle < first && middle > last)
            {

                pivot = middle;
                var temp = input[right];
                input[right] = pivot;
                input[((left + right) / 2)] = temp;
            }


            int i = left;
            int j = right - 1;
            do
            {
                if (j == i)
                {
                    if (input[j] < pivot)
                    {
                        j++;
                    }
                    break;
                }

                if (input[i] < pivot)
                {
                    i++;
                }
                if (input[j] > pivot)
                {
                    j--;
                }
                if (input[j] < pivot && input[i] > pivot)
                {
                    var temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                }

            } while (j >= i);

            var temp1 = input[j];
            input[j] = input[right];
            input[right] = temp1;

        }

    }
}
