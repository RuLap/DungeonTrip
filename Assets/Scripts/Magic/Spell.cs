using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    SpellSO scriptableObject;
    private Vector2 direction;
    GameObject spell;
    bool test = false;
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spell = Instantiate(scriptableObject.skillPrefab);
            spell.transform.position = gameObject.transform.position;
            spell.transform.rotation = Quaternion.Euler(new Vector3(0,0,ViewingAngle()));
            test = true;
        }
    }
    private void FixedUpdate()
    {
        if (test)
        {
            spell.transform.position += Vector3.right * scriptableObject.speed*Time.fixedDeltaTime;
        }
    }*/
    float ViewingAngle()
    {
        UnityEngine.Vector2 direction = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float value = (float)((Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg));
        if (value < 0) value += 360f;
        return value;
    }
}
