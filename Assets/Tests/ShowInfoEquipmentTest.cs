using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class ShowInfoEquipmentTest
    {
        private GameObject game;
        private GameObject dropStatsPanel;

        [UnityTest]
        public IEnumerator ShowInfoEquipmentTestWithEnumeratorPasses()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            
            dropStatsPanel = GameObject.FindGameObjectWithTag("DropInfo");
            var drop = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Drop"));
            yield return new WaitForSecondsRealtime(1f);
            drop.GetComponent<EquipmentDrop>().ShowInfo();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(drop.GetComponent<EquipmentDrop>().DropStatsPanel.GetComponent<Image>().enabled);
        }
    }
}
