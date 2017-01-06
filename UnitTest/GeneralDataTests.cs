using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dungeon6;

namespace UnitTest
{
    [TestClass]
    public class GeneralDataTests
    {
        [TestMethod]
        public void TestDungeonNameLength()
        {
            Assert.AreEqual(GeneralData.DungeonName.Length, 6);
        }

        [TestMethod]
        public void TestVocalsDictionary()
        {
            Assert.AreEqual(GeneralData.VocalsDictionary.Length, 6);
        }

        [TestMethod]
        public void TestConsonantsDictionary()
        {
            Assert.AreEqual(GeneralData.ConsonantsDictionary.Length, 36);
            Assert.AreEqual(GeneralData.ConsonantsDictionary.GetLength(0), 6);


            for (int i = 0; i < GeneralData.ConsonantsDictionary.GetLength(0); i += 1)
            {
                for (int j = 0; j < GeneralData.ConsonantsDictionary.GetLength(1); j += 2)
                {
                    Console.Write(GeneralData.ConsonantsDictionary[i, j]);
                    if (i + 1 > GeneralData.ConsonantsDictionary.GetLength(1))
                    {
                        Assert.Fail();
                        break;
                    }
                    Assert.AreEqual(GeneralData.ConsonantsDictionary[i, j], GeneralData.ConsonantsDictionary[i, j + 1]);
                }
            }
        }
    }
}
