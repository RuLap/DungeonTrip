using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField]
    string jsonString;
    private NpcInfo info;

    [SerializeField]
    private GameObject infoPanel;
    private Text messageUI;

    void Start()
    {
        messageUI = infoPanel.GetComponentInChildren<Text>();
        info = NpcInfo.CreateFromJSON(jsonString);
    }

    public void TellInfo()
    {
        
        if (infoPanel.gameObject.activeInHierarchy)
        {
            return;
        }
        messageUI.text = $"<color=\"blue\">{info.name}:</color> {info.message}";
        infoPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
