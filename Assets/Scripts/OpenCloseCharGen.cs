using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Класс для открытия генерации персонажа
/// </summary>
public class OpenCloseCharGen : MonoBehaviour
{
    // Start is called before the first frame update
    //Аниматор
    Animator anim;
    //Открыт ли инвентарь?
    private bool state = false;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (!state)
            {
                clickOnOn();
            }
            else
                clickOnOff();
            state = !state;
        }
    }
    /// <summary>
    /// Открывает окно
    /// </summary>
    public void clickOnOn()
    {
        StartCoroutine(On());
    }
    /// <summary>
    /// Закрывает окно
    /// </summary>
    public void clickOnOff()
    {
        StartCoroutine(Off());
    }
    IEnumerator On()
    {
        anim.Play("On");
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Off()
    {
        anim.Play("Off");
        yield return new WaitForSeconds(1f);
    }

}
