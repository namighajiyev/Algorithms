using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.DynamicConnectivity
{
    public interface IDynamicConnectivityAlgorithm
    {
        void Connect(int index1, int index2);
        bool IsConnected(int index1, int index2);
    }
}
