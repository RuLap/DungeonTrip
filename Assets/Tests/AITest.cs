using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class AITest
    {
        [UnityTest]
        public async void IsAgressive()
        {
            SceneManager.LoadSceneAsync("Boss1");
            //await Assert.IsTrue(SceneManager.GetActiveScene().isLoaded);

        }
    }
}
