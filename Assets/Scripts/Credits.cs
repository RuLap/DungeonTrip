using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    private bool isEnded = false;
    void Update()
    {
        if (!isEnded)
        {
            if (transform.position.y < 1850)
            {
                transform.Translate(0, 0.5f, 0);
            }
            else
            {
                isEnded = true;
                StartCoroutine(FadeName());
            }
        }
    }

    IEnumerator FadeName()
    {
        while(nameText.color.a < 1)
        {
            nameText.color = new Color(nameText.color.r, nameText.color.g, nameText.color.b, nameText.color.a + 0.05f);
            yield return new WaitForSecondsRealtime(0.15f);
        }
        SceneManager.LoadScene("Magic");
    }
}
