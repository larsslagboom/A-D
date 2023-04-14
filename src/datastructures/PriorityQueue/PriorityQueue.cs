using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            array = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            array = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        public void Add(T x)
        {
            int currentSize = Size();

            if (currentSize + 1 == array.Length)
                doubleArray();

            // Percolate up
            int hole = ++currentSize;
            array[0] = x;

            for (; x.CompareTo(array[hole / 2]) < 0; hole /= 2)
            {
                array[hole] = array[hole / 2];
            }
            array[hole] = x;

            size++;
        }

        public void doubleArray()
        {
            Array.Resize(ref array, array.Length * 2);
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {

            if (Size() == 0) throw new PriorityQueueEmptyException();

            T r = array[1];
            array[1] = array[size];
            array[size] = default;
            size--;
            if(size > 1)
            {
                T x = array[1];
                int current = 1;

                while (x != null)
                {
                    if ((current * 2 + 1) > Size())
                    {
                        if (array[current].CompareTo(array[(current * 2)]) > 0)
                        {
                            array[0] = array[(current * 2)];
                            array[(current * 2)] = x;
                            array[(current)] = array[0];
                        }
                        current *= 2;
                    }
                    else if (array[(current * 2)].CompareTo(array[(current * 2 + 1)]) <= 0)
                    {
                        if (array[current].CompareTo(array[(current * 2)]) > 0)
                        {
                            array[0] = array[(current * 2)];
                            array[(current * 2)] = x;
                            array[(current)] = array[0];
                        }
                        current *= 2;
                    }
                    else
                    {
                        if (array[current].CompareTo(array[(current * 2 + 1)]) > 0)
                        {
                            array[0] = array[(current * 2 + 1)];
                            array[(current * 2 + 1)] = x;
                            array[current] = array[0];
                        }
                        current = current * 2 + 1;
                    }

                    if ((current * 2 + 1) >= Size())
                    {
                        x = default;
                    }
                }
            }

            return r;
        }

        public override string ToString()
        {
            if (Size() == 0) return "";

            StringBuilder queueString = new StringBuilder();
            for (int i = 1; i <= Size(); i++)
            {
                queueString.Append(array[i]);
                if (i < Size()) queueString.Append(" ");
            }

            return queueString.ToString();
        }



        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            int newSize = Size() + 1;

            if (newSize == array.Length)
                doubleArray();

            array[Size() + 1] = x;
            size++;
        }

        public void BuildHeap()
        {
            if (Size() == 0) throw new PriorityQueueEmptyException();

            int LastElementPlace = Size() - 1;

            int i = Size();
            bool elementNotChanged = true;
            bool continueLoop = true;

            while (continueLoop)
            {
                int childFocus = 0;

                if (i % 2 == 0)
                {
                    if (i + 1 <= Size())
                    {
                        if (array[i].CompareTo(array[i + 1]) < 0)
                        {
                            if (array[i].CompareTo(array[i / 2]) < 0)
                            {
                                //linker child
                                childFocus = i;
                            }
                        }
                        else
                        {
                            if (array[i + 1].CompareTo(array[i / 2]) < 0)
                            {
                                //rechter child
                                childFocus = i + 1;
                            }
                        }
                    }
                    else
                    {
                        if (array[i].CompareTo(array[i / 2]) < 0)
                        {
                            //linker child
                            childFocus = i;
                        }
                    }

                    if (childFocus != 0)
                    {
                        array[0] = array[i / 2];
                        array[i / 2] = array[childFocus];
                        array[childFocus] = array[0];
                        elementNotChanged = false;
                    }
                }
                else
                {

                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        if (array[i].CompareTo(array[(i - 1) / 2]) < 0)
                        {
                            //rechter child
                            childFocus = i;
                        }
                    }
                    else
                    {
                        if (array[i - 1].CompareTo(array[(i - 1) / 2]) < 0)
                        {
                            //linker child
                            childFocus = i - 1;
                        }
                    }

                    if (childFocus != 0)
                    {
                        array[0] = array[(i - 1) / 2];
                        array[(i - 1) / 2] = array[childFocus];
                        array[childFocus] = array[0];
                        elementNotChanged = false;
                    }
                }

                if (i <= 1 && elementNotChanged)
                {
                    continueLoop = false;
                }
                else if (i <= 1)
                {
                    i = Size();
                }
                else
                {
                    i -= 2;
                }

                elementNotChanged = true;

            }

        }



    }
}
