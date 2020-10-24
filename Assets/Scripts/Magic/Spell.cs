using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    SpellSO ScriptableObject;
    public float speed;
    public virtual void Move() {
        gameObject.transform.position += Vector3.forward * Time.deltaTime * speed;
    }
    private void Update()
    {
        Move();
    }
}
