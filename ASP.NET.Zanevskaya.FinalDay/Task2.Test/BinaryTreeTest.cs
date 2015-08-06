using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;

namespace Task2.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTree_Test()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(80);
            tree.Add(5);
            tree.Add(2);

            Assert.AreEqual(4, tree.Count);
        }
        [TestMethod]
        public void BinaryTree_Foreach_Test()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(80);
            tree.Add(5);
            tree.Add(2);

            int count = 0;
            foreach (var item in tree)
            {
                count++;
            }
            Assert.AreEqual(4, count);
        }
    }
}
