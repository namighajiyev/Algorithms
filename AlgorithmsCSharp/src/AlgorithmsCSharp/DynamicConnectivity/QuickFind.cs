using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.DynamicConnectivity
{
    //Union too expencive
    // trees are flat but too expensive to keep them flat
    public class QuickFind : IDynamicConnectivityAlgorithm
    {
        int[] nodes;


        public QuickFind(int nodeCount)
        {
            if (nodeCount < 1)
            {
                throw new ArgumentException($"Number of nodes must be greater than zero. Count : {nodeCount}");
            }

            this.nodes = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = i;
            }
        }

        //expensive
        public void Connect(int index1, int index2)
        {
            var groupJoiningTo = nodes[index2];
            var groupJoiningFrom = nodes[index1];
            var length = nodes.Length;
            for (int i = 0; i < length; i++)
            {
                if (nodes[i] == groupJoiningFrom)
                {
                    nodes[i] = groupJoiningTo;
                }
            }

        }

        public bool IsConnected(int index1, int index2)
        {
            return nodes[index1] == nodes[index2];
        }

    }
}
