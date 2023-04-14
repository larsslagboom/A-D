using System.Text;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> head;
        private int size;

        public MyLinkedList()
        {
            head = null;
            size = 0;
        }

        public void AddFirst(T data)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>();
            node.data = data;
            if (head != null)
            {
                node.next = head;
                head = node;
            }
            else
            {
                node.next = null;
                head = node;
            }
            size++;
        }

        public T GetFirst()
        {
            if (head == null)
            {
                throw new MyLinkedListEmptyException();
            }
            return head.data;
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                if (head.next != null)
                {
                    head = head.next;
                    size--;
                }
                else
                {
                    head = null;
                    size--;

                }
            }
            else
            {
                throw new MyLinkedListEmptyException();
            }
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>();
            node.data = data;
            if (index > size || index < 0)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }
            else if (index == 0)
            {
                node.next = head;
                head = node;
                size++;
            }
            else if (index > 1)
            {
                MyLinkedListNode<T> step = new MyLinkedListNode<T>();
                step = head;
                for (int i = 0; i < index - 1; i++)
                {
                    if (step.next != null)
                    {
                        step = step.next;
                    }
                    else
                    {
                        break;
                    }
                }
                if (step.next != null)
                {
                    node.next = step.next;
                    step.next = node;
                }
                else
                {
                    node.next = null;
                    step.next = node;
                }
                size++;
            }
            else if (index == 1)
            {
                node.next = head.next;
                head.next = node;
                size++;
            }
        }

        public override string ToString()
        {
            if (size == 0)
            {
                return "NIL";
            }
            else
            {
                MyLinkedListNode<T> step = head;
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                for (int i = 0; i < size; i++)
                {
                    sb.Append(step.data.ToString());
                    if (step.next != null)
                    {
                        step = step.next;
                    }
                    else
                    {
                        break;
                    }
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