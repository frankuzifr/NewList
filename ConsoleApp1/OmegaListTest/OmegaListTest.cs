using System.Linq;
using ConsoleApp1;
using NUnit.Framework;

namespace OmegaListTest
{
    public class OmegaListTest
    {
        [Test]
        public void Count_ListWithTwoElements_Two()
        {
            var omegaLul = new OmegaList(5){1, 4};
            Assert.AreEqual(omegaLul.Count, 2);
        }

        [Test]
        [TestCase(new int[]{1, 2, 3}, 2)]
        [TestCase(new int[]{5, 4, 3, 7}, 5)]
        [TestCase(new int[]{8}, 8)]
        public void Contains_ManyNumbersAndNumberOfMany_True(int[] many, int sought)
        {
            var omegaLul = new OmegaList(){};
            omegaLul.AddRange(many);
            var contains = omegaLul.Contains(sought);
            Assert.AreEqual(contains, true);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Add_SameElement_ElementWasAdded(int element)
        {
            var omegaLul = new OmegaList() { };
            omegaLul.Add(element);
            Assert.AreEqual(omegaLul[omegaLul.Count - 1], element);
        }

        [Test]
        [TestCase(new int []{1, 2, 3})]
        [TestCase(new int []{1, 2, 3, 4, 5})]
        [TestCase(new int []{1, 2, 3, 4, 5, 6, 7})]
        [TestCase(new int []{1, 2, 3, 4, 5, 6, 7, 8, 9})]
        public void AddRange_ManyElements_ManyElementsAdded(int[] rangeElements)
        {
            var omegaLul = new OmegaList();
            omegaLul.AddRange(rangeElements);
            for (var i = 0; i < omegaLul.Count; i++)
            {
              Assert.AreEqual(omegaLul[i], rangeElements[i]);  
            }
        }

        [Test]
        [TestCase(new int []{5, 1, 7, 8}, 3)]
        [TestCase(new int []{10, 15, 14, 9, 4, 10}, 2)]
        [TestCase(new int []{1, 9, 7, 2}, 4)]
        public void Remove_ManyElementsAndElementOfMany_TrueOnRemovedAndFalseOnContains(int[] many, int removeElementValue)
        {
            var omegaLul = new OmegaList(){1, 2, 3, 4, 5};
            omegaLul.AddRange(many);
            var removed = omegaLul.Remove(removeElementValue);
            Assert.AreEqual(removed, true);
            var contains = omegaLul.Contains(removeElementValue);
            Assert.AreEqual(contains, false);
        }

        [Test]
        [TestCase (new[]{1, 2, 3}, new int[]{10, 11}, new int[] {1, 2, 3}, 2)]
        [TestCase (new[]{1, 2, 3, 4}, new int[]{1, 10, 11}, new int[] {2, 3, 4}, 3)]
        [TestCase (new[]{1, 2}, new int[]{10, 11}, new int[] {1, 2}, 2)]
        [TestCase (new int []{7, 8, 9}, new int[]{8, 9, 10, 11}, new int[] {7}, 4)]
        public void RemoveRange_ManyElementsAndRemovedSetElementsAndFiniteSetElements_CountRemovedElementsAndElementsWasRemoved
            (int[] many, int[] removeElementsValue, int[] resultMany, int countRemovedElements)
        {
            var omegaLul = new OmegaList(){10, 11};
            omegaLul.AddRange(many);
            var count = omegaLul.RemoveRange(removeElementsValue);
            Assert.AreEqual(count, countRemovedElements);
            for (var i = 0; i < omegaLul.Count; i++)
            {
                Assert.AreEqual(omegaLul[i], resultMany[i]);
            }
        }

        [Test]
        public void Clear_Nothing_CountIsZero()
        {
            var omegaLul = new OmegaList() {1, 2, 3, 4, 5};
            omegaLul.Clear();
            Assert.AreEqual(omegaLul.Count, 0);
        }
    }
}