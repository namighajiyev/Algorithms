using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections.SymbolTable
{
    public class BinarySearchTree<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable
    {

        private bool shouldAssertAfterPutDelete = true;

        private Node<TKey, TValue> root;

        public BinarySearchTree()
        {

        }
        public BinarySearchTree(bool shouldAssertAfterPutDelete) : this()
        {
            this.shouldAssertAfterPutDelete = shouldAssertAfterPutDelete;
        }

        public TKey Ceiling(TKey key)
        {
            ThrowIfEmpty();
            if (key == null) { throw new ArgumentNullException(nameof(key)); }
            return Ceiling(root, key);
        }

        private TKey Ceiling(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) { throw new KeyNotFoundException("Ceiling doesn't exists"); }

            int cmp = key.CompareTo(node.Key);

            if (cmp == 0) { return node.Key; }

            if (cmp > 0)
            {
                return Ceiling(node.Right, key);
            }

            try
            {
                TKey ceiling = Ceiling(node.Left, key);
                return ceiling;
            }
            catch (KeyNotFoundException)
            {
            }
            return node.Key;
        }

        public TKey Floor(TKey key)
        {
            ThrowIfEmpty();
            if (key == null) { throw new ArgumentNullException(nameof(key)); }
            return Floor(root, key);
        }

        private TKey Floor(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) { throw new KeyNotFoundException("Floor doesn't exists"); }

            int cmp = key.CompareTo(node.Key);

            if (cmp == 0) { return node.Key; }


            if (cmp < 0)
            {
                return Floor(node.Left, key);
            }


            try
            {
                TKey floor = Floor(node.Right, key);
                return floor;
            }
            catch (KeyNotFoundException)
            {
            }
            return node.Key;
        }

        public bool Contains(TKey key)
        {
            try
            {
                Get(key);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

            return true;
        }

        public void Delete(TKey key)
        {
            root = Delete(root, key);
            DoAssertCheck();
        }

        private Node<TKey, TValue> Delete(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) { return null; }
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) { node.Left = Delete(node.Left, key); }
            else if (cmp > 0) { node.Right = Delete(node.Right, key); }
            else
            {
                if (node.Right == null) { return node.Left; }
                if (node.Left == null) { return node.Right; }
                var temp = node;
                node = Min(temp.Right);
                node.Right = DeleteMin(temp.Right);
                node.Left = temp.Left;
            }

            node.Size = 1 + Size(node.Left) + Size(node.Right);
            return node;
        }

        public void DeleteMax()
        {
            ThrowIfEmpty();
            root = DeleteMax(root);
            DoAssertCheck();
        }

        private Node<TKey, TValue> DeleteMax(Node<TKey, TValue> node)
        {
            if (node.Right == null) { return node.Left; }
            node.Right = DeleteMax(node.Right);
            node.Size = 1 + Size(node.Left) + Size(node.Right);
            return node;
        }

        public void DeleteMin()
        {
            ThrowIfEmpty();
            root = DeleteMin(root);
            DoAssertCheck();
        }
        private Node<TKey, TValue> DeleteMin(Node<TKey, TValue> node)
        {
            //if left is null then node itself is the min
            if (node.Left == null) { return node.Right; }
            node.Left = DeleteMin(node.Left);
            node.Size = 1 + Size(node.Left) + Size(node.Right);
            return node;
        }

        private void ThrowIfEmpty()
        {
            if (IsEmpty()) { throw new InvalidOperationException("Tree is empty"); }
        }

        public TValue Get(TKey key)
        {
            if (key == null) { throw new ArgumentNullException(nameof(key)); }
            return Get(root, key).Value;
        }

        private Node<TKey, TValue> Get(Node<TKey, TValue> node, TKey key)
        {
            if (node == null)
            {
                throw new KeyNotFoundException();
            }
            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) return Get(node.Left, key);
            else if (cmp > 0) return Get(node.Right, key);
            else return node;

        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public IEnumerable<TKey> Keys()
        {
            var queue = new Queue<TKey>();
            Keys(root, queue);
            return queue;
        }

        private void Keys(Node<TKey, TValue> node, Queue<TKey> queue)
        {
            if (node == null) { return; }
            Keys(node.Left, queue);
            queue.Enqueue(node.Key);
            Keys(node.Right, queue);
        }

        public IEnumerable<TKey> Keys(TKey lowKey, TKey highKey)
        {
            if (lowKey == null) { throw new ArgumentNullException(nameof(lowKey)); }
            if (highKey == null) { throw new ArgumentNullException(nameof(highKey)); }
            if (lowKey.CompareTo(highKey) > 0) { throw new ArgumentException($"{nameof(lowKey) } cannot be greater than {nameof(highKey)}"); }
            var queue = new Queue<TKey>();
            Keys(root, queue, lowKey, highKey);
            return queue;
        }

        private void Keys(Node<TKey, TValue> node, Queue<TKey> queue, TKey lowKey, TKey highKey)
        {
            if (node == null) { return; }
            int compLow = lowKey.CompareTo(node.Key);
            int compHigh = highKey.CompareTo(node.Key);
            if (compLow < 0) { Keys(node.Left, queue, lowKey, highKey); }
            if (compLow <= 0 && compHigh >= 0) { queue.Enqueue(node.Key); }
            if (compHigh > 0) { Keys(node.Right, queue, lowKey, highKey); }
        }

        public IEnumerable<TKey> KeysLevelOrder()
        {
            var keys = new Queue<TKey>();
            var queue = new Queue<Node<TKey, TValue>>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node == null) continue;
                keys.Enqueue(node.Key);
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
            return keys;
        }

        public TKey Max()
        {
            var max = Max(root);
            return max.Key;
        }
        private Node<TKey, TValue> Max(Node<TKey, TValue> node)
        {
            if (node.Right == null) { return node; }
            return Max(node.Right);
        }

        public TKey Min()
        {
            var min = Min(root);
            return min.Key;
        }

        private Node<TKey, TValue> Min(Node<TKey, TValue> node)
        {
            if (node.Left == null) { return node; }
            return Min(node.Left);
        }

        public void Put(TKey key, TValue value)
        {
            root = Put(root, key, value);
            DoAssertCheck();
        }

        private Node<TKey, TValue> Put(Node<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null) { return new Node<TKey, TValue>(key, value); }

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0)
            {
                node.Left = Put(node.Left, key, value);
            }
            else if (cmp > 0)
            {
                node.Right = Put(node.Right, key, value);
            }
            else
            { //update value
                node.Value = value;
            }

            node.Size = 1 + Size(node.Left) + Size(node.Right);

            return node;
        }

        //how many keys < k ?
        public int Rank(TKey key)
        {
            return Rank(root, key);
        }

        private int Rank(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) { return 0; }

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0) { return Rank(node.Left, key); }

            else if (cmp > 0) { return 1 + Size(node.Left) + Rank(node.Right, key); }

            else return Size(node.Left);
        }

        public TKey Select(int rank)
        {
            if (rank < 0 || rank >= Size()) throw new InvalidOperationException($"parameter {nameof(rank)} must be greater than 0 and less than or equal to {Size()}");
            Node<TKey, TValue> node = Select(root, rank);
            return node.Key;
        }

        private Node<TKey, TValue> Select(Node<TKey, TValue> node, int rank)
        {
            if (node == null) { return null; }
            var leftSize = Size(node.Left);
            if (leftSize > rank) { return Select(node.Left, rank); }
            else if (leftSize < rank) { return Select(node.Right, rank - leftSize - 1); }
            return node;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(Node<TKey, TValue> node)
        {
            return node == null ? 0 : node.Size;
        }

        public int Size(TKey lowKey, TKey highKey)
        {
            return Contains(highKey) ? 1 + Rank(highKey) - Rank(lowKey)
                : Rank(highKey) - Rank(lowKey);
        }

        private void DoAssertCheck()
        {
            if (shouldAssertAfterPutDelete)
            {
                AssertCheck();
            }
        }

        public void AssertCheck()
        {
            if (!Check())
            {
                throw new InvalidOperationException("BST is in inconsistent state");
            }
        }
        private bool Check()
        {
            if (!IsBST()) Console.WriteLine("Not in symmetric order");
            if (IsSizeConsistent()) Console.WriteLine("Subtree counts not consistent");
            if (!IsRankConsistent()) Console.WriteLine("Ranks not consistent");
            return IsBST() && IsSizeConsistent() && IsRankConsistent();
        }

        private bool IsBST()
        {
            return IsBST(root, null, null);
        }

        private bool IsBST(Node<TKey, TValue> node, Node<TKey, TValue> minNode, Node<TKey, TValue> maxNode)
        {
            if (node == null) return true;
            if (minNode != null && node.Key.CompareTo(minNode.Key) <= 0) return false;
            if (maxNode != null && node.Key.CompareTo(maxNode.Key) >= 0) return false;
            return IsBST(node.Left, minNode, node) && IsBST(node.Right, node, maxNode);
        }

        private bool IsSizeConsistent() { return IsSizeConsistent(root); }
        private bool IsSizeConsistent(Node<TKey, TValue> node)
        {
            if (node == null) return true;
            if (node.Size != Size(node.Left) + Size(node.Right) + 1) return false;
            return IsSizeConsistent(node.Left) && IsSizeConsistent(node.Right);
        }

        private bool IsRankConsistent()
        {
            for (int i = 0; i < Size(); i++)
                if (i != Rank(Select(i))) return false;
            foreach (var key in Keys())
                if (key.CompareTo(Select(Rank(key))) != 0) return false;
            return true;
        }

    }
}
