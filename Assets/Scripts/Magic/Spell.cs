using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public SpellSO scriptableObject;
    private float duration;
    private Vector3 cursorCast;
    private Vector3 moveDirection;
    private AudioSource audioSource;
    private void Start()
    {
        duration = scriptableObject.duration;
        cursorCast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorCast.z = 0f;
        moveDirection = cursorCast - gameObject.transform.position;
        moveDirection.z = 0;
        moveDirection.Normalize();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(scriptableObject.sound);
    }
    private void FixedUpdate()
    {
        if (duration >= 0f)
        {
            switch (scriptableObject.spellType)
            {
                case SpellSO.SpellType.За_мышкой:
                    gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.fixedDeltaTime * scriptableObject.speed);
                    break;
                case SpellSO.SpellType.В_сторону_курсора:
                    gameObject.transform.position = transform.position + moveDirection * scriptableObject.speed * Time.fixedDeltaTime;
                    break;
                case SpellSO.SpellType.На_земле:
                    Transform let = gameObject.transform.Find("Container/Particle System");
                    gameObject.transform.position = cursorCast;
                    let.gameObject.transform.localScale += new Vector3(scriptableObject.speed*Time.fixedDeltaTime, scriptableObject.speed * Time.fixedDeltaTime, 0);
                    break;
            }
            
            duration -= Time.fixedDeltaTime;
        }
        else
            Destroy(this.gameObject);
    }
}
