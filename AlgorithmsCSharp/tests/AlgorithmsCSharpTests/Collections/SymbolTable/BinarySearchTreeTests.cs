
using AlgorithmsCSharp.Collections.SymbolTable;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Collections.SymbolTable
{

    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int, int> tree;
        private IComparable[] arr;
        private IComparable[] arrSorted;
        private IComparable[] arrSortedDesc;
        private int treeSizeOriginal;
        private bool shouldAssertAfterPutDelete = false;

        [SetUp]
        public void TestInitialize()
        {
            this.arr = TestData.NewUnsortedArray.Distinct().ToArray();
            this.arrSorted = TestData.NewUnsortedArray.Distinct().ToArray();
            new AlgorithmsCSharp.Sorting.MergeSort().Sort(arrSorted);
            this.arrSortedDesc = this.arrSorted.ToArray().Reverse().ToArray();
        }

        [Test]
        public void BinarySearchTreeTest()
        {
            InitAndFillTree();
            int index = 0;
            while (!tree.IsEmpty())
            {
                DeleteMinCheck(index);
                index++;
                Assert.IsTrue(treeSizeOriginal - index == tree.Size());
            }

            InitAndFillTree();
            index = 0;
            while (!tree.IsEmpty())
            {
                DeleteMaxCheck(index);
                index++;
                Assert.IsTrue(treeSizeOriginal - index == tree.Size());
            }

            InitAndFillTree();
            index = 0;
            int minIndex = 0;
            int maxIndex = 0;
            while (!tree.IsEmpty())
            {
                if (index % 2 == 0)
                {
                    DeleteMinCheck(minIndex);
                    minIndex++;
                }
                else
                {
                    DeleteMaxCheck(maxIndex);
                    maxIndex++;
                }
                Assert.IsTrue(treeSizeOriginal - minIndex - maxIndex == tree.Size());
                index++;
            }

            InitAndFillTree();
            index = 0;
            while (index < arr.Length)
            {
                var key = (int)arr[index];
                DeleteCheck(index, key);
                index++;
                Assert.IsTrue(treeSizeOriginal - index == tree.Size());
            }
            CeilingFloorEtcTests();
        }

        private void DeleteMaxCheck(int index)
        {
            var max = tree.Max();
            tree.DeleteMax();
            Assert.IsFalse(tree.Contains((int)arrSortedDesc[index]));
            Assert.IsFalse(tree.Contains(max));
        }

        private void DeleteMinCheck(int index)
        {
            var min = tree.Min();
            tree.DeleteMin();
            Assert.IsFalse(tree.Contains((int)arrSorted[index]));
            Assert.IsFalse(tree.Contains(min));
        }

        private void DeleteCheck(int index, int key)
        {
            tree.Delete(key);
            Assert.IsFalse(tree.Contains((int)arr[index]));
            Assert.IsFalse(tree.Contains(key));
        }


        private void InitAndFillTree(IComparable[] arrray = null)
        {
            if (arrray == null) { arrray = this.arr; }
            this.tree = new BinarySearchTree<int, int>(shouldAssertAfterPutDelete);
            for (int i = 0; i < arrray.Length; i++)
            {
                tree.Put((int)arrray[i], MakeValue((int)arrray[i]));
            }
            Assert.IsFalse(tree.IsEmpty());
            this.treeSizeOriginal = tree.Size();
            Assert.IsTrue(this.treeSizeOriginal == arrray.Length);
        }

        private static int MakeValue(int i)
        {
            return i + 1; // +1 just to make value different
        }


        private void CeilingFloorEtcTests()
        {
            InitAndFillTree();

            //ceiling
            var randomCeilingIndex = TestHelper.NewRandom().Next(1, this.arrSorted.Length - 1);
            var keyCeiling = (int)this.arrSorted[randomCeilingIndex] + 1;
            var ceiling = this.tree.Ceiling(keyCeiling);
            Assert.IsTrue(ceiling >= keyCeiling);
            Assert.IsTrue(ceiling > (int)this.arrSorted[randomCeilingIndex]);
            Assert.IsTrue(ceiling == (int)this.arrSorted[randomCeilingIndex + 1]);

            //floor
            var randomFloorIndex = TestHelper.NewRandom().Next(1, this.arrSorted.Length - 1);
            var keyFloor = (int)this.arrSorted[randomFloorIndex] - 1;
            var floor = this.tree.Floor(keyFloor);
            Assert.IsTrue(floor <= keyFloor);
            Assert.IsTrue(floor == (int)this.arrSorted[randomFloorIndex - 1]);
            Assert.IsTrue(floor < (int)this.arrSorted[randomFloorIndex + 1]);

            //contains
            var containsIndex = TestHelper.NewRandom().Next(1, this.arrSorted.Length - 1);
            Assert.IsTrue(tree.Contains((int)this.arrSorted[containsIndex]));
            Assert.IsFalse(tree.Contains((int)this.arrSorted[arrSorted.Length - 1] + 1));

            //get
            var getIndex = TestHelper.NewRandom().Next(1, this.arrSorted.Length - 1);
            Assert.IsTrue(tree.Get((int)arrSorted[getIndex]) == MakeValue((int)arrSorted[getIndex]));
            bool notFound = false;
            try
            {
                tree.Get((int)arrSorted[arrSorted.Length - 1] + 1);
            }
            catch (KeyNotFoundException)
            {
                notFound = true;
            }
            Assert.IsTrue(notFound);

            //keys
            var keys = tree.Keys().Cast<IComparable>().ToArray();
            Assert.IsTrue(arrSorted.SequenceEqual(keys));

            //keys low high
            var lowIndex = TestHelper.NewRandom().Next((arrSorted.Length - 1) / 2);
            var highIndex = TestHelper.NewRandom().Next((arrSorted.Length + 2) / 2, arrSorted.Length - 1);
            keys = tree.Keys((int)arrSorted[lowIndex], (int)arrSorted[highIndex]).Cast<IComparable>().ToArray();
            Assert.IsTrue(keys.Count() == highIndex - lowIndex + 1);

            //KeysLevelOrder - needs aditional tests for KeysLevelOrder...
            keys = tree.KeysLevelOrder().Cast<IComparable>().ToArray();
            Assert.IsTrue(keys.Count() == arrSorted.Length);
            Assert.IsFalse(keys.SequenceEqual(arrSorted));

            //min max
            var max = tree.Max();
            var min = tree.Min();
            Assert.IsTrue(max == (int)arrSorted[arrSorted.Length - 1]);
            Assert.IsTrue(min == (int)arrSorted[0]);

            //rank
            int rankIndex, rank = 0;
            for (int i = 0; i < 10; i++)
            {
                rankIndex = TestHelper.NewRandom().Next((arrSorted.Length - 1) / 2);
                rank = tree.Rank((int)arrSorted[rankIndex]);
                Assert.AreEqual(rank, rankIndex);
            }

            //size
            Assert.IsTrue(tree.Size() == arrSorted.Length);

            //size low high
            lowIndex = TestHelper.NewRandom().Next((arrSorted.Length - 1) / 2);
            highIndex = TestHelper.NewRandom().Next((arrSorted.Length + 2) / 2, arrSorted.Length - 1);
            Assert.IsTrue(tree.Size((int)arrSorted[lowIndex], (int)arrSorted[highIndex]) == highIndex - lowIndex + 1);

            //select
            rankIndex = TestHelper.NewRandom().Next((arrSorted.Length - 1));
            var key = (int)arrSorted[rankIndex];
            var selectedKey = tree.Select(tree.Rank(key));
            Assert.IsTrue(key == selectedKey);
        }

    }
}