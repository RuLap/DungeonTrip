using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryAudioTests
    {
        private GameObject game;
        private InventoryAudio audio;

        [UnityTest]
        public IEnumerator InventoryAudioPlayHealUseTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("UI").GetComponent<InventoryAudio>();
            audio.PlayHealUse();
            yield return new WaitForSecondsRealtime(0.05f);
            Assert.IsTrue(audio.Source.clip.name == "Использвание зелья здоровья");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayManaUseTest()
        {
            audio.PlayManaUse();
            yield return new WaitForSecondsRealtime(0.05f);
            Assert.IsTrue(audio.Source.clip.name == "Использование зелья магии");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayEquipArmorTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("UI").GetComponent<InventoryAudio>();
            yield return new WaitForSecondsRealtime(1f);
            audio.PlayEquipArmor();
            yield return new WaitForSecondsRealtime(0.000001f);
            Assert.IsTrue(audio.Source.clip.name == "Надели броню");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayUnequipArmorTest()
        {
            yield return new WaitForSecondsRealtime(2f);
            audio.PlayUnequipArmor();
            yield return new WaitForSecondsRealtime(0.000001f);
            Assert.IsTrue(audio.Source.clip.name == "Сняли броню");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayEquipSwordTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("UI").GetComponent<InventoryAudio>();
            yield return new WaitForSecondsRealtime(1f);
            audio.PlayEquipSword();
            yield return new WaitForSecondsRealtime(0.000001f);
            Assert.IsTrue(audio.Source.clip.name == "Надели меч");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayUnequipSwordTest()
        {
            yield return new WaitForSecondsRealtime(2f);
            audio.PlayUnequipSword();
            yield return new WaitForSecondsRealtime(0.000001f);
            Assert.IsTrue(audio.Source.clip.name == "Сняли меч");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayDropArmorTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("UI").GetComponent<InventoryAudio>();
            yield return new WaitForSecondsRealtime(1f);
            audio.PlayDropArmor();
            yield return new WaitForSecondsRealtime(0.000001f);
            Assert.IsTrue(audio.Source.clip.name == "Бросили доспехи");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayDropSwordTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("UI").GetComponent<InventoryAudio>();
            yield return new WaitForSecondsRealtime(1f);
            audio.PlayDropSword();
            yield return new WaitForSecondsRealtime(0.000001f);
            Assert.IsTrue(audio.Source.clip.name == "Бросили меч");
        }

        [UnityTest]
        public IEnumerator InventoryAudioPlayExitButtonTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("UI").GetComponent<InventoryAudio>();
            yield return new WaitForSecondsRealtime(1f);
            audio.PlayExitButton();
            yield return new WaitForSecondsRealtime(0.001f);
            Assert.IsTrue(audio.Source.clip.name == "Звук нажатия кнопки");
        }
    }
}
