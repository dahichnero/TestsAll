using GraphMM;

namespace GraphMM.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private void Check2DArrays(int[,] expected, int[,] actual)
        {
            if (expected.GetLength(1) != actual.GetLength(1) ||
                expected.GetLength(0) != actual.GetLength(0))
            {
                Assert.Fail("Invalid length of array");
            }

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                for (int j = 0; j < actual.GetLength(1); j++)
                {
                    if (actual[i, j] != expected[i, j])
                    {
                        Assert.Fail("Fail on ({0}, {1}) Expected: {2} Actual: {3}",
                            i, j, expected[i, j], actual[i, j]);
                    }
                }
            }
            Assert.Pass();
        }


        [Test]
        public void EmptyNodeEmptyMatrix()
        {
            List<(int, int)> nodes = new();
            int[,] expected = new int[0, 0];
            int[,] actual = Graph.ToAdjacencyMatrix(nodes);
            Check2DArrays(expected, actual);
        }


        [Test]
        public void TwoNodesToMatrix()
        {
            List<(int, int)> nodes = [(1, 2)];

            int[,] expected = new int[,]
            {
                { 0, 1 },
                { 0, 0 },
            };
            int[,] actual = Graph.ToAdjacencyMatrix(nodes);
            Check2DArrays(expected, actual);
        }

        [Test]
        public void TwoNodesToMatrixUnorderedGraph()
        {
            List<(int, int)> nodes = [(1, 2), (2, 1)];

            int[,] expected = new int[,]
            {
                { 0, 1 },
                { 1, 0 },
            };
            int[,] actual = Graph.ToAdjacencyMatrix(nodes);
            Check2DArrays(expected, actual);
        }

        [Test]
        public void ThreeNodesToMatrix()
        {
            List<(int, int)> nodes = [(1, 2), (1, 3), (3, 2)];

            int[,] expected = new int[,]
            {
                { 0, 1, 1 },
                { 0, 0, 0 },
                { 0, 1, 0 },
            };
            int[,] actual = Graph.ToAdjacencyMatrix(nodes);
            Check2DArrays(expected, actual);
        }

        [Test]
        public void MatrixComplexExample()
        {
            List<(int, int)> nodes = [(1, 2), (1, 3), (1, 4), (2, 5), (3, 5), (4, 3), (4, 5)];

            int[,] expected = new int[,]
            {
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0 },
            };
            int[,] actual = Graph.ToAdjacencyMatrix(nodes);
            Check2DArrays(expected, actual);
        }

        [Test]
        public void EmptyNodeEmptyList()
        {
            List<(int, int)> nodes = new();
            var expected = new Dictionary<int, List<int>>();
            var actual = Graph.ToAdjacencyList(nodes);
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void TwoNodesToList()
        {
            List<(int, int)> nodes = [(1, 2)];
            var expected = new Dictionary<int, List<int>> 
            {
                { 1, [2] },
                { 2, [ ] }
            };
            var actual = Graph.ToAdjacencyList(nodes);
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void TwoNodesToListUnorderedGraph()
        {
            List<(int, int)> nodes = [(1, 2), (2, 1)];
            var expected = new Dictionary<int, List<int>>
            {
                { 1,  [ 2 ] },
                { 2,  [ 1 ] }
            };
            var actual = Graph.ToAdjacencyList(nodes);
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void ThreeNodesToList()
        {
            List<(int, int)> nodes = [(1, 2), (1, 3), (3, 2)];
            var expected = new Dictionary<int, List<int>>
            {
                { 1, [ 2, 3 ] },
                { 2, [ ] },
                { 3, [ 2 ] },
            };
            var actual = Graph.ToAdjacencyList(nodes);
            Assert.That(actual, Is.EquivalentTo(expected));
        }


        [Test]
        public void CompexExampleList()
        {
            List<(int, int)> nodes = [(1, 2), (1, 3), (1, 4), (2, 5), (3, 5), (4, 3), (4, 5)];
            var expected = new Dictionary<int, List<int>>
            {
                { 1, [ 2, 3, 4 ] },
                { 2, [ 5 ] },
                { 3, [ 5 ] },
                { 4, [ 3, 5 ] },
                { 5, [ ] },
            };
            var actual = Graph.ToAdjacencyList(nodes);
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void TwoLocationsOnePath()
        {
            List<(int, int)> nodes = [(1, 2), (2, 1)];
            Assert.IsTrue(Graph.HasConnection(nodes, 2, 1));
        }

        [Test]
        public void TwoLocationsOnePath_1_to_2_reachable()
        {
            List<(int, int)> nodes = [(1, 2)];
            Assert.IsTrue(Graph.HasConnection(nodes, 1, 2));
        }

        [Test]
        public void TwoLocationsOnePath_1_to_2_unreachable()
        {
            List<(int, int)> nodes = [(1, 2)];
            Assert.IsFalse(Graph.HasConnection(nodes, 2, 1));
        }

        [Test]
        public void ThreeLocations()
        {
            List<(int, int)> nodes = [(1, 2), (2, 3)];
            Assert.IsTrue(Graph.HasConnection(nodes, 1, 3));
        }

        [Test]
        public void ThreeLocations_ureachable()
        {
            List<(int, int)> nodes = [(1, 3), (2, 3)];
            Assert.IsFalse(Graph.HasConnection(nodes, 1, 2));
        }

        [Test]
        public void ThreeLocations_reachable_by_3()
        {
            List<(int, int)> nodes = [(1, 3), (2, 3), (3, 2)];
            Assert.IsTrue(Graph.HasConnection(nodes, 1, 2));
        }

        [Test]
        public void RandomTestReachable_1()
        {
            List<(int, int)> nodes = [(1, 2), (2, 3), (2, 4), (4, 5), (5, 3)];
            Assert.IsTrue(Graph.HasConnection(nodes, 1, 3));
        }

        [Test]
        public void RandomTestReachable_2()
        {
            List<(int, int)> nodes = [(1, 3), (1, 4), (1, 5), (4, 3), (3, 2), (5, 1)];
            Assert.IsTrue(Graph.HasConnection(nodes, 5, 2));
        }

        [Test]
        public void RandomTestUnreachable_1()
        {
            List<(int, int)> nodes = [(1, 3), (1, 4), (2, 4), (4, 3), (3, 2), (5, 1)];
            Assert.IsFalse(Graph.HasConnection(nodes, 3, 5));
        }

        [Test]
        public void RandomTestUnreachable_2()
        {
            List<(int, int)> nodes = [(1, 2), (1, 3), (1, 5), (3, 5), (6, 4)];
            Assert.IsFalse(Graph.HasConnection(nodes, 1, 6));
        }

        [Test]
        public void LineReachable()
        {
            List<(int, int)> nodes = [(1, 2), (2, 3), (3, 4), (4, 5), (5, 6), (6, 7)];
            Assert.IsTrue(Graph.HasConnection(nodes, 1, 7));
        }

        [Test]
        public void LineUnreachable()
        {
            List<(int, int)> nodes = [(1, 2), (2, 3), (3, 4), (5, 6), (6, 7)];
            Assert.IsFalse(Graph.HasConnection(nodes, 1, 7));
        }
    }
}