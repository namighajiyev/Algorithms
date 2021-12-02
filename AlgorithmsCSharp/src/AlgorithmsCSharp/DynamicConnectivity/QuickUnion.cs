using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.DynamicConnectivity
{
    // Trees can get tall.
    // Find too expensive (could be N array accesses)
    public class QuickUnion : IDynamicConnectivityAlgorithm
    {
        int[] nodes;
        public int Count { get; private set; }

        public QuickUnion(int nodeCount)
        {
            if (nodeCount < 1)
            {
                throw new ArgumentException($"Number of nodes must be greater than zero. Count : {nodeCount}");
            }

            Count = nodeCount;

            this.nodes = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = i;
            }
        }

        public void Connect(int index1, int index2)
        {
            var rootIndex1 = FindRootIndex(index1);
            var rootIndex2 = FindRootIndex(index2);
            if (rootIndex1 == rootIndex2) { return; } //allready connected.
            nodes[rootIndex1] = rootIndex2;
            this.Count--;
        }

        //recursive version of finding root
        private int FindRootIndexRecursive(int index)
        {
            if (nodes[index] == index)
            {
                return index;
            }
            else
            {
                return FindRootIndexRecursive(nodes[index]);
            }
        }


        private int FindRootIndex(int index)
        {
            while (nodes[index] != index)
            {
                index = nodes[index];
            }

            return index;
        }

        public bool IsConnected(int index1, int index2)
        {
            var rootIndex1 = FindRootIndex(index1);
            var rootIndex2 = FindRootIndex(index2);
            return rootIndex1 == rootIndex2;
        }
    }
}
