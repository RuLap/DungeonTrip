using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryTest
    {
        private Player player;

        [UnityTest]
        public IEnumerator InventoryAddPotion()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            player = GameObject.Find("Player").GetComponent<Player>();
            DataBase db = Camera.main.GetComponent<DataBase>();
            int potions = (player.Inventory.Items[0] as PotionItem).Count;
            player.Inventory.AddItem(db.Potions[0]);
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue((player.Inventory.Items[0] as PotionItem).Count == (potions + 1));
            GameObject.Destroy(gameGameObject);
        }
    }
}
