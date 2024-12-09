using NUnit.Framework;
using MyCollections;
using System;
using System.Collections.Generic;

namespace MyCollectionTests
{
    public class StackTests
    {

        [Test]
        public void PeekEmptyStackRaisesException()
        {
            IntStack stack = new IntStack();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void PopEmptyStackRaisesException()
        {
            IntStack stack = new IntStack();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void PushAndPopOneElement()
        {
            IntStack stack = new IntStack();
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void PushOneElementCheckCount()
        {
            IntStack stack = new IntStack();
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }


        [Test]
        public void PushManyElementsAndPeek()
        {
            IntStack stack = new IntStack();
            
            for (int i = 1; i <= 2100; i++)
            {
                stack.Push(i);
            }
            int expected = 2100;
            int actual = stack.Peek();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2100, stack.Count);
        }

        [Test]
        public void PushManyElementsAndPop()
        {
            IntStack stack = new IntStack();

            for (int i = 1; i <= 2100; i++)
            {
                stack.Push(i);
            }
            int expected = 2100;
            int actual = stack.Pop();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2099, stack.Count);
        }

        [Test]
        public void PushManyElementsAndPopAll()
        {
            IntStack stack = new IntStack();
            List<int> expected = new List<int>();
            List<int> actual = new List<int>();
            Random rng = new Random();

            for (int i = 1; i <= 10000; i++)
            {
                int value = rng.Next(-100000, 100000);
                stack.Push(value);
                expected.Add(value);
            }
            
            while (stack.Count > 0)
            {
                actual.Add(stack.Pop());
            }
            actual.Reverse();

            CollectionAssert.AreEqual(expected, actual);
            Assert.AreEqual(0, stack.Count);
        }


    }
}