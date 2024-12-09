using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollections;

namespace MyCollectionTests
{
    public class QueueTests
    {
        [Test]
        public void PeekEmptyQueueRaisesException()
        {
            IntQueue queue = new IntQueue();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());

        }
        [Test]
        public void DequeueEmptyQueueRaisesException()
        {
            IntQueue queue = new IntQueue();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
        [Test]
        public void EnqueueAndDequeueOneElement()
        {
            IntQueue queue = new IntQueue();
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }
        [Test]
        public void EnqueueOneElementCheckCount()
        {
            IntQueue queue = new IntQueue();
            queue.Enqueue(4);
            Assert.AreEqual(1, queue.Count);
        }
        [Test]
        public void EnqueueManyElementsAndPeek()
        {
            IntQueue queue = new IntQueue();
            for (int i = 1; i <= 100; i++)
            {
                queue.Enqueue(i);
            }
            int expected = 1;
            int actual = queue.Peek();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(100, queue.Count);
        }
        [Test]
        public void EnqueueManyElementsAndDequeue()
        {
            IntQueue queue = new IntQueue();
            for (int i = 1; i <= 100; i++)
            {
                queue.Enqueue(i);
            }
            int expected = 1;
            int actual = queue.Dequeue();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(99, queue.Count);
        }
        [Test]
        public void EnqueueManyElementsAndDequeueAll()
        {
            IntQueue queue = new IntQueue();
            List<int> expected = new List<int>();
            List<int> actual = new List<int>();
            Random rng = new Random();
            for (int i = 1; i <= 100; i++)
            {
                int value = rng.Next(1, 100);
                queue.Enqueue(value);
                expected.Add(value);
            }
            while (queue.Count > 0)
            {
                actual.Add(queue.Dequeue());
            }
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, queue.Count);
        }
    }
}
