using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace Tests
{
    public class MenuWorkTest
    {
        private GameObject game;

        [Test]
        public void MenuWorkChangeFullScreenTest()
        {
            bool isFull = MenuWork.isFullScreen;
            
            MenuWork.ChangeFullScreenMode();
            Assert.IsTrue(isFull != MenuWork.isFullScreen);
        }

        [UnityTest]
        public IEnumerator MenuWorkEnterMainMenuTest()
        {
            //var menu = GameObject.FindObjectOfType<MenuWork>();
            MenuWork.EnterMainMenu();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(SceneManager.GetActiveScene().name == "MainMenu");
        }

        [UnityTest]
        public IEnumerator MenuWorkChangeVolumeTest()
        {
            float val = -40;
            var mix = MonoBehaviour.Instantiate(Resources.Load<GameObject>("AudioMixer"));
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            var menu = GameObject.FindObjectOfType<MenuWork>();
            menu.ChangeVolume(val);
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsFalse(mix.isStatic);
        }

        [UnityTest]
        public IEnumerator MenuWorkChangeQualityTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            //var menu = GameObject.FindObjectOfType<MenuWork>();
            int qual = 2;
            MenuWork.ChangeQuality(qual);
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(qual == MenuWork.quality);
        }

        [UnityTest]
        public IEnumerator MenuWorkExitPressedTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            //var menu = GameObject.FindObjectOfType<MenuWork>();
            MenuWork.ExitPressed();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(Application.isPlaying);
        }
        
    }
}
