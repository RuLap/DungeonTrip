using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuWorkTest: MonoBehaviour
    {
        private void Start()
        {
            var menu = GameObject.FindObjectOfType<MenuWork>();
            SceneManager.sceneLoaded += EnterMainMenu;
        }
        // A Test behaves as an ordinary method
        [Test]
        public void MenuWorkChangeFullScreenTest()
        {
            var menu = GameObject.FindObjectOfType<MenuWork>();
            bool isFull = true;
            
            menu.ChangeFullScreenMode();
            Assert.IsTrue(isFull != GameObject.FindObjectOfType<MenuWork>().isFullScreen);
        }

        [Test]
        public void MenuWorkEnterMainMenuTest()
        {
            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MenuWorkTestWithEnumeratorPasses()
        {
            var menu = GameObject.FindObjectOfType<MenuWork>();
            //var scene = GameObject.FindGameObjectsWithTag("MainMenu");
            menu.EnterMainMenu();
            yield return new WaitForSecondsRealtime(1f);
            Assert.IsTrue(SceneManager.GetActiveScene().name == "MainMenu");
        }
    }
}
