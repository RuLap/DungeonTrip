using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AttackAudioTests
    {
        private GameObject game;
        private AttackAudio audio;

        [UnityTest]
        public IEnumerator AttackAudioPlayNoDamageTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("SwordSlot").GetComponent<AttackAudio>();
            audio.PLayNoDamage();
            Assert.IsTrue(audio.Source.clip.name == "ВзмахМечом");
            GameObject.Destroy(game);
        }

        [UnityTest]
        public IEnumerator AttackAudioPlayDamageTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            audio = GameObject.Find("SwordSlot").GetComponent<AttackAudio>();
            audio.PlayDamage();
            yield return new WaitForSecondsRealtime(0.05f);
            Assert.IsTrue(audio.Source.clip.name == "Удар мечом по противнику");
        }
    }
}
