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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject let = Instantiate(testSpell1);
            let.transform.position = gameObject.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject let = Instantiate(testSpell2);
            let.transform.position = gameObject.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject let = Instantiate(testSpell3);
            let.transform.position = gameObject.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject let = Instantiate(testSpell4);
            let.transform.position = gameObject.transform.position;
        }
    }
}
