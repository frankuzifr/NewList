using ConsoleApp1;
using NUnit.Framework;

namespace OmegaListTest
{
    public class OmegaListTest<T>
    {
        [Test]
        [TestCase (new[]{1, 2, 3}, 3)]
        [TestCase(new[]{"a", "b", "c", "d"}, 4)]
        [TestCase(new[]{.12f, .35f, .02f, 1.26f, 3.65f}, 5)]
        public void Count_ManyElementsAndRequiredAmountElements_CountElements(T[] many, T amount)
        {
            var omegaLul = new OmegaList<T>();
            Assert.AreEqual(omegaLul.Count, amount);
        }

        [Test]
        [TestCase(new[]{1, 2, 3}, 2)]
        [TestCase(new[]{"a", "b", "c", "d"}, "b")]
        [TestCase(new[]{.12f, .35f, .02f, 1.26f, 3.65f}, .35f)]
        public void Contains_ManyNumbersAndNumberOfMany_True(T[] many, T sought)
        {
            var omegaLul = new OmegaList<T>();
            omegaLul.AddRange(many);
            var contains = omegaLul.Contains(sought);
            Assert.AreEqual(contains, true);
        }

        [Test]
        [TestCase(2)]
        [TestCase("b")]
        [TestCase(.29f)]
        public void Add_SameElement_ElementWasAdded(T element)
        {
            var omegaLul = new OmegaList<T>();
            omegaLul.Add(element);
            Assert.AreEqual(omegaLul[omegaLul.Count - 1], element);
        }

        [Test]
        [TestCase(new[]{1, 2, 3})]
        [TestCase(arg: new string[] { "a", "b" })] //конфликт перегрузки между двумя конструкторами TestCaseAttribute
        [TestCase(new[]{.12f, .35f, .02f, 1.26f, 3.65f})]
        public void AddRange_ManyElements_ManyElementsAdded(T[] rangeElements)
        {
            var omegaLul = new OmegaList<T>();
            omegaLul.AddRange(rangeElements);
            for (var i = 0; i < omegaLul.Count; i++)
            {
              Assert.AreEqual(omegaLul[i], rangeElements[i]);  
            }
        }

        [Test]
        [TestCase(new[]{5, 1, 7, 8}, 3)]
        [TestCase(new[]{"a", "b", "c", "d"}, "b")]
        [TestCase(new[]{.25f, .36f, 1.65f, .39f}, .36f)]
        public void Remove_ManyElementsAndElementOfMany_TrueOnRemovedAndFalseOnContains(T[] many, T removeElementValue)
        {
            var omegaLul = new OmegaList<T>();
            omegaLul.AddRange(many);
            var removed = omegaLul.Remove(removeElementValue);
            Assert.AreEqual(removed, true);
            var contains = omegaLul.Contains(removeElementValue);
            Assert.AreEqual(contains, false);
        }

        [Test]
        [TestCase (new[]{1, 2, 3}, new[]{10, 11}, new[] {1, 2, 3}, 2)]
        [TestCase (new[]{"a", "b", "c", "d"}, new[]{"a", "b", "c"}, new[] {"d"}, 3)]
        [TestCase (new[]{.15f, .65f, .34f, 1.32f, 3.25f}, new[]{.15f, 1.32f}, new[] {.65f, .34f, 3.25f}, 2)]
        public void RemoveRange_ManyElementsAndRemovedSetElementsAndFiniteSetElements_CountRemovedElementsAndElementsWasRemoved
            (T[] many, T[] removeElementsValue, T[] resultMany, int countRemovedElements)
        {
            var omegaLul = new OmegaList<T>();
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
            var omegaLul = new OmegaList<T>();
            omegaLul.Clear();
            Assert.AreEqual(omegaLul.Count, 0);
        }
        
    }

    /*public class Test
    {
        
        [Test]
        public void Clear_Nothing_CountIsZero2()
        {
            var omegaLul = new OmegaList<int>(){1, 2};
            omegaLul.Clear();
            Assert.AreEqual(omegaLul.Count, 0);
        }
        
    }*/
}