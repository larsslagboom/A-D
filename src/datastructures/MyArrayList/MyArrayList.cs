using System.Text;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;
        private int cap;

        public MyArrayList(int capacity)
        {
            cap = capacity;
            size = 0;
        }

        public void Add(int n)
        {
            if (data == null)
            {
                data = new int[1];
                data[0] = n;
                size = 1;
            }
            else if (cap > data.Length)
            {
                int[] tempData = data;
                data = new int[tempData.Length + 1];
                for (int i = 0; i < tempData.Length; i++)
                {
                    data[i] = tempData[i];
                }
                data[tempData.Length] = n;
                size += 1;
            }
            else
            {
                throw new MyArrayListFullException();
            }
        }

        public int Get(int index)
        {
            if (data != null)
            {
                if (index < data.Length && index >= 0)
                {
                    return data[index];
                }
                else
                {
                    throw new MyArrayListIndexOutOfRangeException();
                }
            }
            else
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
        }

        public void Set(int index, int n)
        {
            if (data != null)
            {
                if (index < data.Length && index >= 0)
                {
                    data[index] = n;
                }
                else
                {
                    throw new MyArrayListIndexOutOfRangeException();
                }
            }
            else
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
        }

        public int Capacity()
        {
            return cap;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            data = null;
            size = 0;
        }

        public int CountOccurences(int n)
        {
            int occurences = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i] == n)
                {
                    occurences++;
                }
            }
            return occurences;
        }
        public override string ToString()
        {
            if (size == 0)
            {
                return "NIL";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                for (int i = 0; i < size; i++)
                {
                    sb.Append(data[i].ToString());
                    if (i != size - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
                return sb.ToString();
            }

        }
    }
}
