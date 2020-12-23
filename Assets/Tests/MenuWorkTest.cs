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
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("MenuObject"));
            var menu = GameObject.FindObjectOfType<MenuWork>();
            bool isFull = menu.isFullScreen;

            menu.ChangeFullScreenMode();
            Assert.IsTrue(isFull != menu.isFullScreen);
        }

        [UnityTest]
        public IEnumerator MenuWorkEnterMainMenuTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("MenuObject"));
            var menu = GameObject.FindObjectOfType<MenuWork>();
            menu.EnterMainMenu();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(SceneManager.GetActiveScene().name == "MainMenu");
        }

        [UnityTest]
        public IEnumerator MenuWorkExitPressedTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("MenuObject"));
            yield return new WaitForSecondsRealtime(1f);
            var menu = GameObject.FindObjectOfType<MenuWork>();
            menu.ExitPressed();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(Application.isPlaying);
        }
        //тесты для внутриигрового меню
        [Test]
        public void OpenCloseMenuTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("GameMenuObject"));
            var menu = GameObject.Find("Canvas").transform.Find("GameMenuPanel").GetComponent<MenuWork>();
            bool isOpen = menu.isOpened;
            menu.OpenCloseMenu();
            Assert.IsTrue(isOpen != menu.isOpened);
        }
        [Test]
        public void ContinueGameTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("GameMenuObject"));
            var menu = GameObject.Find("Canvas").transform.Find("GameMenuPanel").GetComponent<MenuWork>();
            bool isOpen = menu.isOpened;
            menu.ContinueGame();
            Assert.IsTrue(isOpen == menu.isOpened);
        }
        [Test]
        public void ButtonCloseTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("GameMenuObject"));
            var menu = GameObject.Find("Canvas").transform.Find("GameMenuPanel").GetComponent<MenuWork>();
            bool isOpen = menu.isOpened;
            menu.ButtonClose();
            Assert.IsTrue(isOpen == menu.isOpened);
        }

    }
}
