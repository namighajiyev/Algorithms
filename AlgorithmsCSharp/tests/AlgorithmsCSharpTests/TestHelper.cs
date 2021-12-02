using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
   public class TestHelper
    {

        public static Random NewRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }
    }
}
