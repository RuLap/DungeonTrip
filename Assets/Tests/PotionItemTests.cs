using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PotionItemTests
    {
        PotionItem potion;
        [Test]
        public void PotionItemAddToStackTest()
        {
            potion = new PotionItem(0, null, "", 100, 0, 1);

            potion.Use();
            Assert.IsTrue(potion.Count == 0);
            
            potion.Use();
            Assert.IsTrue(potion.Count == 0);
        }

        [Test]
        public void PotionItemUseTest()
        {
            potion.Count = 0;
            potion.AddToStack();
            Assert.IsTrue(potion.Count == 1);

            potion.Count = 99;
            potion.AddToStack();
            Assert.IsTrue(potion.Count == 99);
        }
    }
}
