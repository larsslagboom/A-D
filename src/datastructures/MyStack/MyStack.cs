namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        MyLinkedList<T> stack = new MyLinkedList<T>();
        public bool IsEmpty()
        {
            if (stack.Size() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }
            if (stack.Size() == 1)
            {
                T temp = stack.head.data;
                stack.RemoveFirst();
                return temp;
            }
            else
            {
                T temp = stack.head.data;
                int j = stack.Size();
                for (int i = 0; i < j; i++)
                {
                    if (i != j - 1)
                    {
                        Push(stack.head.data);
                    }
                    else
                    {
                        temp = stack.head.data;

                    }
                    stack.RemoveFirst();
                }
                return temp;
            }
        }

        public void Push(T data)
        {
            if (stack.Size() == 0)
            {
                stack.AddFirst(data);
            }
            else
            {
                stack.Insert(stack.Size(), data);
            }
        }

        public T Top()
        {
            if (IsEmpty())
            {
                throw new MyStackEmptyException();
            }
            if (stack.Size() == 1)
            {
                return stack.head.data;
            }
            else
            {
                MyLinkedListNode<T> step = stack.head;
                for (int i = 0; i < stack.Size(); i++)
                {
                    if (step.next.next != null)
                    {
                        step = step.next;
                    }
                    else
                    {
                        break;
                    }
                }
                return step.next.data;
            }
        }
    }
}
