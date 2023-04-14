using System.Collections.Generic;
using System.Text;

namespace AD
{
    public class Opgave6
    {
        public static string ForwardString(List<int> list, int from)
        {
            StringBuilder forwardedString = new StringBuilder();

            for (int i = from; i < list.Count; i++)
            {
                forwardedString.Append((i == list.Count) ? list[i].ToString() : list[i].ToString() + " ");
            }

            return forwardedString.ToString();
        }
        
        public static string BackwardString(List<int> list, int to)
        {
            StringBuilder backwardString = new StringBuilder();

            for (int i = list.Count; i > to; i--)
            {
                backwardString.Append((i == to) ? list[i - 1].ToString() : list[i - 1].ToString() + " ");
            }

            return backwardString.ToString();
        }

        public static void Run()
        {
            List<int> list = new List<int>(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11});

            System.Console.WriteLine(ForwardString(list, 3));
            System.Console.WriteLine(ForwardString(list, 7));
            System.Console.WriteLine(BackwardString(list, 3));
            System.Console.WriteLine(BackwardString(list, 7));
        }
    }
}
