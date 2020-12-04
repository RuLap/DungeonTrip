using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class NPCTests
    {
        GameObject game;
        Npc npc;
        Text infoPanel;

        [UnityTest]
        public IEnumerator NPCTellInfoTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            npc = GameObject.FindGameObjectsWithTag("NPC")[0].GetComponent<Npc>();
            infoPanel = GameObject.Find("Canvas").transform.Find("InfoPanel").transform.Find("Text").GetComponent<Text>();
            npc.TellInfo();
            yield return new WaitForSecondsRealtime(5f);
            Assert.IsTrue(infoPanel.text.ToLower().Contains(npc.Info.name.ToLower()));
            GameObject.Destroy(game);
        }

        [UnityTest]
        public IEnumerator NPCCloseInfoPanelTest()
        {
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Game"));
            yield return new WaitForSecondsRealtime(1f);
            npc = GameObject.FindGameObjectsWithTag("NPC")[0].GetComponent<Npc>();
            infoPanel = GameObject.Find("Canvas").transform.Find("InfoPanel").transform.Find("Text").GetComponent<Text>();
            npc.CloseInfoPanel();
            yield return new WaitForSecondsRealtime(0.5f);
            Assert.IsFalse(infoPanel.IsActive());
            GameObject.Destroy(game);
        }

        [Test]
        public void NPCInfoTest()
        {
            NpcInfo info = NpcInfo.CreateFromJSON("npc1-1");
            Assert.IsNotNull(info);
        }
    }
}
