using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private IntroData data;
    private Text storyText;
    private string[] sentences;
    [SerializeField]
    private Text skipText;

    void Start()
    {
        storyText = GetComponentInChildren<Text>();
        data = IntroData.CreateFromJSON("Intro");
        sentences = data.story.Split('|');
        StartCoroutine(PrintText());
        skipText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skipText.enabled)
            {
                PlayerPrefs.SetString("Scene", "Magic");
                SceneManager.LoadScene("LoadScreen");
            }
        }
        if (Input.anyKeyDown)
        {
            skipText.enabled = true;
            StartCoroutine(WaitShownSkip());
        }
    }

    /// <summary>
    /// Ждет 2 секунды и убирает подсказку для пропуска
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitShownSkip()
    {
        yield return new WaitForSecondsRealtime(2);
        skipText.enabled = false;
    }

    /// <summary>
    /// Выводит предысторию последовательно
    /// </summary>
    /// <returns></returns>
    IEnumerator PrintText()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            for (int j = 0; j < sentences[i].Length; j++)
            {
                storyText.text += sentences[i][j];
                yield return new WaitForSecondsRealtime(0.05f);
            }
            yield return new WaitForSecondsRealtime(2);
            storyText.text = string.Empty;
        }
    }
}
