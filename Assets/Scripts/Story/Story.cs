using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    private StoryData data;
    private Text storyText;
    private string[] sentences;
    [SerializeField]
    private Text skipText;
    private bool isIntro;
    [SerializeField]
    private GameObject credits;

    void Start()
    {
        string name = PlayerStats.LoadFromJson().name;
        isIntro = SceneManager.GetActiveScene().name == "Beginning" ? true : false;
        storyText = GetComponentInChildren<Text>();
        if (isIntro)
            data = StoryData.CreateFromJSON("Intro");
        else
            data = StoryData.CreateFromJSON("Ending");
        data.story = data.story.Replace("{Имя главного героя}", name);
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
                if (isIntro)
                {
                    PlayerPrefs.SetString("Scene", "Level1");
                    SceneManager.LoadScene("LoadScreen");
                }
                else
                {
                    SceneManager.LoadScene("Magic");//сделать главное меню
                }
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
            if (isIntro)
            {
                storyText.text = string.Empty;
            }
        }
        if (!isIntro)
        {
            StartCoroutine(FadeText());
            credits.SetActive(true);
        }
    }

    /// <summary>
    /// Затемнение текста
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeText()
    {
        while(storyText.color.a > 0)
        {
            storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, storyText.color.a - 0.05f);
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
