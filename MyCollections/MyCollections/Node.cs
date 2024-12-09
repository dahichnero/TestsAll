namespace MyCollections
{
    internal class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
    }
}