using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class IntStack
    {
        private Node top;
        private int count;
        public void Push(int value)
        {

            var NewNode = new Node(value);
            if (top == null)
            {
                top = NewNode;
                count++;
            }
            else
            {
                NewNode.Next = top;
                top = NewNode;
                count++;
            }
        }
        public int Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Стэк пуст");
            }
            else
            {
                int x = top.Value;
                top = top.Next;
                count--;
                return x;

            }

        }
        public int Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Стэк пуст");
            }
            else
            {
                return top.Value;
            }

        }
        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
