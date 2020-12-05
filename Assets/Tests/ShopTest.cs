using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ShopTest
    {
        private Shop shop;
        private Player player;

        [UnityTest]
        public IEnumerator ShopOpenCloseTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            shop = GameObject.FindGameObjectWithTag("TXVillagePropsStallTable").GetComponent<Shop>();
            bool isOpened = shop.IsShopOpened;
            shop.OpenCloseShop();
            Assert.IsTrue(isOpened != shop.IsShopOpened);
            yield return new WaitForSecondsRealtime(0.5f);
            shop.OpenCloseShop();
            Assert.IsTrue(isOpened == shop.IsShopOpened);
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator BuyProductTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            shop = GameObject.FindGameObjectWithTag("TXVillagePropsStallTable").GetComponent<Shop>();
            int money = GameObject.FindObjectOfType<Player>().PlayerStats.money;
            DataBase db = Camera.main.GetComponent<DataBase>();
            int price = db.Potions[0].price;
            yield return new WaitForSecondsRealtime(0.5f);
            shop.BuyProduct(db.Potions[0]);
            Assert.IsTrue((money-price) == GameObject.FindObjectOfType<Player>().PlayerStats.money);

            money = GameObject.FindObjectOfType<Player>().PlayerStats.money;
            player = GameObject.Find("Player").GetComponent<Player>();
            (player.Inventory.Items[0] as PotionItem).Count = 99;
            yield return new WaitForSecondsRealtime(0.5f);
            shop.BuyProduct(db.Potions[0]);
            Assert.IsTrue(money == GameObject.FindObjectOfType<Player>().PlayerStats.money);

            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopIsClosedTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            shop = GameObject.FindGameObjectWithTag("TXVillagePropsStallTable").GetComponent<Shop>();
            bool isOpened = shop.IsShopOpened;
            shop.ShopIsClosed();
            Assert.IsTrue(isOpened == shop.IsShopOpened);
        }

        [UnityTest]
        public IEnumerator CloseShopTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            shop = GameObject.FindGameObjectWithTag("TXVillagePropsStallTable").GetComponent<Shop>();
            bool isOpened = shop.IsShopOpened;
            shop.CloseShop();
            Assert.IsTrue(isOpened == shop.IsShopOpened);
        }
    }
}
