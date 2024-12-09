using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class IntQueue
    {
        private Node begin;
        private Node end;
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void Enqueue(int value)
        {
            var NewNode = new Node(value);
            if (begin == null)
            {
                begin = NewNode;
                end = NewNode;
                count++;
            }
            else
            {
                end.Next = NewNode;
                end = NewNode;
                count++;
            }
        }
        public int Dequeue()
        {
            if (begin == null)
            {
                throw new InvalidOperationException("Очередь пуста");
            }
            else
            {
                int x = begin.Value;
                begin = begin.Next;
                count--;
                return x;
            }
        }
        public int Peek()
        {
            if (begin == null)
            {
                throw new InvalidOperationException("Очередь пуста");
            }
            else
            {
                return begin.Value;
            }

        }
        /*public void Reversed()
        {
            IntQueue queue = new IntQueue();
            IntStack stack = new IntStack();
            while (begin!=null)
            {
                stack.Push(queue.Peek());
                queue.Dequeue();
            }
            while ()
        }*/
    }
}
