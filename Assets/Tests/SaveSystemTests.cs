using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class SaveSystemTests
    {
        [UnityTest]
        public IEnumerator SaveSystemNewGameTest()
        {
            SaveSystem.NewGame();
            yield return new WaitForSecondsRealtime(2f);
            Assert.IsTrue(SceneManager.GetActiveScene().name == "Beginning");
        }

        [UnityTest]
        public IEnumerator SaveSystemLoadGameTest()
        {
            SaveSystem.Info.Level = 3;
            SaveSystem.Info.name = "Level";
            SaveSystem.LoadGame();
            yield return new WaitForSecondsRealtime(2f);
            Assert.IsTrue(SceneManager.GetActiveScene().name == "Level3");
        }
    }
}
