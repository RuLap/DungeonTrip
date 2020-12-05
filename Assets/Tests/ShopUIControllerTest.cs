using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ShopUIControllerTest
    {
        [UnityTest]
        public IEnumerator ShopUIControllerOnShopOpenTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            shop.OnShopOpen();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(shop.isActiveAndEnabled);
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopUIControllerOnShopCloseTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            shop.OnShopOpen();
            shop.OnShopClose();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(!shop.isActiveAndEnabled);
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopUIControllerOnClickRightTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            int index = shop.Index;
            shop.OnCickRight();
            yield return new WaitForSecondsRealtime(0.5f);
            if (index == 0)
            {
                Assert.IsTrue(!shop.Potions.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(shop.Armor.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(!shop.Swords.activeSelf);
            }
            else if (index == 1)
            {
                Assert.IsTrue(!shop.Potions.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(!shop.Armor.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(shop.Swords.activeSelf);   
            }
            else
            {
                Assert.IsTrue(shop.Potions.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(shop.Armor.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(shop.Swords.activeSelf);
            }
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopUIControllerOnClickLeftTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            int index = shop.Index;
            shop.OnCickLeft();
            if (index == 0)
            {
                Assert.IsTrue(!shop.Potions.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(!shop.Armor.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(shop.Swords.activeSelf);
            }
            else if (index == 1)
            {
                Assert.IsTrue(shop.Potions.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(!shop.Armor.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(!shop.Swords.activeSelf);
            }
            else
            {
                Assert.IsTrue(!shop.Potions.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(shop.Armor.activeSelf);
                yield return new WaitForSecondsRealtime(0.5f);
                Assert.IsTrue(!shop.Swords.activeSelf);
            }
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopUIControllerOnClickArmorTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            shop.OnClickArmor();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(!shop.Potions.activeSelf);
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsTrue(shop.Armor.activeSelf);
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsTrue(!shop.Swords.activeSelf);
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopUIControllerOnClickSwordsTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            shop.OnClickSwords();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(!shop.Potions.activeSelf);
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsTrue(!shop.Armor.activeSelf);
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsTrue(shop.Swords.activeSelf);
            GameObject.Destroy(gameGameObject);
        }

        [UnityTest]
        public IEnumerator ShopUIControllerOnClickPotionsTest()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var shop = GameObject.Find("Canvas").transform.Find("Shop").GetComponent<ShopUIController>();
            yield return new WaitForSecondsRealtime(1f);
            shop.OnClickPotions();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(shop.Potions.activeSelf);
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsTrue(!shop.Armor.activeSelf);
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsTrue(!shop.Swords.activeSelf);
            GameObject.Destroy(gameGameObject);
        }
    }
}
