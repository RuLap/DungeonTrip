using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    private int progress = 0;
    private Image bar;

    private void Start()
    {
        bar = GetComponent<Image>();
        StartCoroutine(Load());
    }
    private void Update()
    {
        if(progress == 100)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
        }
    }
    IEnumerator Load()
    {
        while (true)
        {
            progress++;
            bar.fillAmount = progress / 100.0f;
            yield return new WaitForSecondsRealtime(Random.Range(0.01f, 0.2f));
        }
    }
}
