using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.DynamicConnectivity
{
    public class PathCompressionTwoPassVersion : IDynamicConnectivityAlgorithm
    {
        int[] nodes;
        int[] weights;
        public int Count { get; private set; }

        public PathCompressionTwoPassVersion(int nodeCount)
        {

            if (nodeCount < 1)
            {
                throw new ArgumentException($"Number of nodes must be greater than zero. Count : {nodeCount}");
            }

            Count = nodeCount;

            this.nodes = new int[nodeCount];
            this.weights = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = i;
                weights[0] = 1;
            }
        }

        public void Connect(int index1, int index2)
        {
            var rootIndex1 = FindRootIndex(index1);
            var rootIndex2 = FindRootIndex(index2);

            if (rootIndex1 == rootIndex2) { return; } //allready connected.

            if (weights[rootIndex1] < weights[rootIndex2])
            {
                nodes[rootIndex1] = rootIndex2;
                weights[rootIndex2] += weights[rootIndex1];
            }
            else
            {
                nodes[rootIndex2] = rootIndex1;
                weights[rootIndex1] += weights[rootIndex2];
            }

            this.Count--;

        }

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

        //while loop version of finding root
        private int FindRootIndex(int index)
        {
            var visitedIndexes = new List<int>();
            while (nodes[index] != index)
            {
                visitedIndexes.Add(index);
                index = nodes[index];
            }

            foreach (var visitedIndex in visitedIndexes)
            {
                nodes[visitedIndex] = index;
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
