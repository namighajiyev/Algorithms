using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections.SymbolTable
{
    public class Node<TKey, TValue> where TKey : IComparable
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Node<TKey, TValue> Left { get; set; }
        public Node<TKey, TValue> Right { get; set; }

        //todo should default to 1.
        public int Size { get; set; } = 1;

        public Node(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

    }
}
