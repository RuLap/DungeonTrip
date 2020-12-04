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

    public NpcInfo Info => info;

    void Start()
    {
        messageUI = infoPanel.GetComponentInChildren<Text>();
        info = NpcInfo.CreateFromJSON(jsonString);
    }

    /// <summary>
    /// Отображение сообщения npc на панели
    /// </summary>
    public void TellInfo()
    {
        if (infoPanel.gameObject.activeInHierarchy)
        {
            return;
        }
        messageUI.text = string.Empty;
        messageUI.text = $"<color=\"#ff5500\">{info.name}:</color> ";
        infoPanel.SetActive(true);
        StartCoroutine("WriteMessage");
        Time.timeScale = 0;
    }

    /// <summary>
    /// Закрытие панели
    /// </summary>
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1;
        StopCoroutine("WriteMessage");
    }

    /// <summary>
    /// Выводит текст побуквенно с задержкой
    /// </summary>
    /// <returns></returns>
    IEnumerator WriteMessage()
    {
        messageUI.text = $"<color=\"#ff5500\">{info.name}:</color> ";
        string msg = messageUI.text;
        for(int i = 0; i < info.message.Length; i++)
        {
            msg += info.message[i];
            messageUI.text = msg;
            yield return new WaitForSecondsRealtime(0.06f);
        }
    }
}
