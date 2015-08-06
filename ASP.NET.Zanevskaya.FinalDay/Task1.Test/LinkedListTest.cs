using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Test
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void CreateNode_Test()
        {
            CustomLinkedList<int> instI = new CustomLinkedList<int>();

            instI.Add(300);
            instI.Add(500);
            instI.Add(85);
            instI.Add(85);

            Assert.AreEqual(3, instI.Count);
        }
        [TestMethod]
        public void CreateNode_Foreach_Test()
        {
            CustomLinkedList<int> instI = new CustomLinkedList<int>();
            instI.Add(300);
            instI.Add(500);
            instI.Add(85);
            instI.Add(85);

            int count = 0;
            foreach (var item in instI)
            {
                count++;
            }
            Assert.AreEqual(3, count);
        }
    }
}
