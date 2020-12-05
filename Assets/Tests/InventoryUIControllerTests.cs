using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class InventoryUIControllerTests
    {
        GameObject game;
        InventoryUIController inventory;

        [UnityTest]
        public IEnumerator InventoryUIControllerOnInventoryOpenTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            inventory = GameObject.FindObjectOfType<InventoryUIController>();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnInventoryOpen();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(inventory.isActiveAndEnabled);
        }

        [UnityTest]
        public IEnumerator InventoryUIControllerOnInventoryCloseTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            inventory = GameObject.FindObjectOfType<InventoryUIController>();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnInventoryOpen();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnInventoryClose();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsFalse(inventory.isActiveAndEnabled);
        }

        [UnityTest]
        public IEnumerator InventoryUIControllerOnPotionSelectTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            inventory = GameObject.FindObjectOfType<InventoryUIController>();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnInventoryOpen();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnPotionSelect(GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("Potions").Find("SmallHPCell").gameObject);
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(inventory.UseButton.isActiveAndEnabled);
            Assert.IsFalse(inventory.DropButton.interactable);
            Assert.IsFalse(inventory.EquipButton.interactable);
            Assert.IsFalse(inventory.TakeOffButton.interactable);
        }

        [UnityTest]
        public IEnumerator InventoryUIControllerOnEquipmentSelectTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            inventory = GameObject.FindObjectOfType<InventoryUIController>();
            yield return new WaitForSecondsRealtime(1f);
            var db = Camera.main.GetComponent<DataBase>();
            inventory.Inventory.Items[6] = db.Swords[0];
            inventory.OnInventoryOpen();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnEquipmentSelect(GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("Equipment").Find("Image").gameObject);
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsFalse(inventory.UseButton.interactable);
            Assert.IsTrue(inventory.DropButton.isActiveAndEnabled);
            Assert.IsTrue(inventory.EquipButton.isActiveAndEnabled);
            Assert.IsFalse(inventory.TakeOffButton.interactable);
        }

        [UnityTest]
        public IEnumerator InventoryUIControllerOnEquipedSelectTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            inventory = GameObject.FindObjectOfType<InventoryUIController>();
            yield return new WaitForSecondsRealtime(1f);
            var db = Camera.main.GetComponent<DataBase>();
            inventory.Inventory.Items[12] = db.Swords[0];
            inventory.OnInventoryOpen();
            yield return new WaitForSecondsRealtime(1f);
            inventory.OnEquipedSelect(GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("Equiped").Find("WeaponCell").gameObject);
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsFalse(inventory.UseButton.interactable);
            Assert.IsTrue(inventory.DropButton.isActiveAndEnabled);
            Assert.IsFalse(inventory.EquipButton.interactable);
            Assert.IsTrue(inventory.TakeOffButton.isActiveAndEnabled);
        }

        [UnityTest]
        public IEnumerator InventoryUIControllerOnItemRemoveTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            inventory = GameObject.FindObjectOfType<InventoryUIController>();
            yield return new WaitForSecondsRealtime(1f);
            var db = Camera.main.GetComponent<DataBase>();
            inventory.Inventory.Items[12] = db.Swords[0];
            inventory.OnInventoryOpen();
            yield return new WaitForSecondsRealtime(1f);
            var cell = GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("Equiped").Find("WeaponCell").gameObject;
            inventory.OnEquipedSelect(cell);
            yield return new WaitForSecondsRealtime(0.5f);
            inventory.OnItemRemove();
            yield return new WaitForSecondsRealtime(0.5f);
            var item = cell.transform.Find("Button").GetComponent<Button>();
            Assert.IsFalse(item.isActiveAndEnabled);
        }
    }
}
