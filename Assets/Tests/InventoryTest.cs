using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryTest
    {
        private GameObject game;
        private Player player;
        private DataBase db;

        [UnityTest]
        public IEnumerator InventoryAddItemTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            player = GameObject.Find("Player").GetComponent<Player>();
            db = Camera.main.GetComponent<DataBase>();

            //Добавить зелье
            int potions = (player.Inventory.Items[0] as PotionItem).Count;
            if (potions == 99)
            {
                //Зелий 99
                player.Inventory.AddItem(db.Potions[0]);
                yield return new WaitForSecondsRealtime(1f);
                Assert.IsTrue((player.Inventory.Items[0] as PotionItem).Count == potions);
            }
            else
            {
                //Зелий меньше 99
                player.Inventory.AddItem(db.Potions[0]);
                yield return new WaitForSecondsRealtime(1f);
                Assert.IsTrue((player.Inventory.Items[0] as PotionItem).Count == (potions + 1));
            }
        }

        [Test]
        public void InventoryOpenCloseTest()
        {
            bool isOpened = player.Inventory.IsInventoryOpened;

            //Открываем, если инвентарь закрыт и закрываем, если открыт
            player.Inventory.OpenCloseInventory();
            Assert.IsTrue(isOpened != player.Inventory.IsInventoryOpened);
            player.Inventory.OpenCloseInventory();
            Assert.IsTrue(isOpened == player.Inventory.IsInventoryOpened);
        }

        [Test]
        public void InventoryRemoveItemTest()
        {
            var items = player.Inventory.Items;
            int index = 0;
            for(int i = 6; i < items.Count; i++)
            {
                if(items[i] != null)
                {
                    player.Inventory.RemoveItem(i);
                    index = i;
                }
            }
            if (index != 0)
            {
                Assert.IsNull(items[index]);
            }
        }

        [Test]
        public void InventoryReplaceToEquipment()
        {
            var items = player.Inventory.Items;
            var swordEquiped = items[12];
            Item replace = null;
            player.Inventory.AddItem(db.Swords[0]);
            for(int i = 6; i < 12; i++)
            {
                if(items[i] is WeaponItem)
                {
                    replace = items[i];
                    player.Inventory.ReplaceToEquipment(i);
                }
            }
            Assert.AreEqual(replace, items[12]);
        }

        [Test]
        public void InventoryReplaceFromEquipment()
        {
            var items = player.Inventory.Items;
            bool isFull = true;
            if(items[12] is null)
            {
                items[12] = db.Swords[0];
            }
            items[12] = db.Swords[0];
            for(int i = 6; i < 12; i++)
            {
                if(items[i] is null)
                {
                    isFull = false;
                }
            }
            if (isFull)
            {
                //Некуда убирать
                var equiped = items[12];
                player.Inventory.ReplaceFromEquipment(12);
                Assert.AreEqual(equiped, items[12]);
            }
            else
            {
                //Есть пустой слот в инвентаре
                player.Inventory.ReplaceFromEquipment(12);
                Assert.IsNull(items[12]);
            }
        }

        [Test]
        public void InventoryUsePotionTest()
        {
            (player.Inventory.Items[0] as PotionItem).Count = 0;
            player.Inventory.AddItem(db.Potions[0]);
            int potions = 1;

            //Есть 1 зелье
            player.Inventory.UsePotion(0);
            Assert.IsTrue((player.Inventory.Items[0] as PotionItem).Count == (potions - 1));

            //Зелий 0
            player.Inventory.UsePotion(0);
            Assert.IsTrue((player.Inventory.Items[0] as PotionItem).Count == 0);
        }

        [Test]
        public void InventoryHasEmptyWeaponSlotTest()
        {
            var items = player.Inventory.Items;

            //Пустой слот
            items[12] = null;
            Assert.IsTrue(player.Inventory.HasEmptyWeaponSlot());

            //Слот занят
            items[12] = db.Swords[0];
            Assert.IsFalse(player.Inventory.HasEmptyWeaponSlot());
        }

        [Test]
        public void InventoryHasEmptyArmorSlotTest()
        {
            var items = player.Inventory.Items;
         
            //Пустой слот
            items[13] = null;
            Assert.IsTrue(player.Inventory.HasEmptyArmorSlot());

            //Слот занят
            items[13] = db.Armors[0];
            Assert.IsFalse(player.Inventory.HasEmptyArmorSlot());
        }

        [Test]
        public void InventorySaveInfoLoadTest()
        {
            InventorySaveInfo info = InventorySaveInfo.LoadFromJson();
            Assert.IsNotNull(info);
        }

        [Test]
        public void StoryDataLoadTest()
        {
            StoryData data = StoryData.CreateFromJSON("Intro");
            Assert.IsNotNull(data);
            Assert.IsTrue(data.story.Contains("Давным"));

            StoryData data1 = StoryData.CreateFromJSON("Ending");
            Assert.IsNotNull(data1);
            Assert.IsTrue(data1.story.Contains("Поздравляю"));
        }
    }
}
