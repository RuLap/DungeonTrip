using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject testSpell1;
    public GameObject testSpell2;
    public GameObject testSpell3;
    public GameObject testSpell4;

    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (testSpell1 != null)
            {
                GameObject let = Instantiate(testSpell1);
                let.transform.position = gameObject.transform.position;
                player.ReduceMana(20);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (testSpell2 != null)
            {
                GameObject let = Instantiate(testSpell2);
                let.transform.position = gameObject.transform.position;
                player.ReduceMana(20);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (testSpell3 != null)
            {
                GameObject let = Instantiate(testSpell3);
                let.transform.position = gameObject.transform.position;
                player.ReduceMana(20);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (testSpell4 != null)
            {
                GameObject let = Instantiate(testSpell4);
                let.transform.position = gameObject.transform.position;
                player.ReduceMana(20);
            }
        }
    }
}
