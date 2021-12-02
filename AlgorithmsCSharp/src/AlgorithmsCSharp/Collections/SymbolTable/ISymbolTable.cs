using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections.SymbolTable
{
    public interface ISymbolTable<TKey, TValue> where TKey : IComparable
    {
        //put key-value pair into the table
        void Put(TKey key, TValue value);

        //get value by key. throws KeyNotFoundException
        TValue Get(TKey key);

        //get key-value pair by key. throws KeyNotFoundException
        void Delete(TKey key);

        //delete pair with the smallest key
        void DeleteMin();

        //delete pair with the largest key
        void DeleteMax();

        bool Contains(TKey key);

        bool IsEmpty();

        //number of key value pairs
        int Size();

        //number of keys in [lowKey..highKey] 
        int Size(TKey lowKey, TKey highKey);

        IEnumerable<TKey> Keys();

        //keys in [lowKey..highKey] in sorted order
        IEnumerable<TKey> Keys(TKey lowKey, TKey highKey);

        TKey Min();

        TKey Max();

        //largest key less than or equal to key
        TKey Floor(TKey key);

        //smallest key greater than or equal
        TKey Ceiling(TKey key);

        //number of keys less than
        int Rank(TKey key);

        //key of rank k
        TKey Select(int rank);










    }
}
