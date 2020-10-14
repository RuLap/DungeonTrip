using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечает за управление
/// положением игрока
/// </summary>
public class Movement : MonoBehaviour
{
    private float speed = 5;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite[] moveSprites = new Sprite[5];

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = moveSprites[0];
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = move.normalized * speed;
        
        //Idle
        if(move.x == 0 && move.y == 0)
        {
            spriteRenderer.sprite = moveSprites[0];
        }

        if(move.x == 0)
        {
            //Up
            if(move.y > 0)
            {
                spriteRenderer.sprite = moveSprites[1];
            }
            //Down
            if(move.y < 0)
            {
                spriteRenderer.sprite = moveSprites[2];
            }
        }

        if(move.y == 0)
        {
            //Left
            if(move.x < 0)
            {
                spriteRenderer.sprite = moveSprites[3];
            }
            //Right
            if(move.x > 0)
            {
                spriteRenderer.sprite = moveSprites[4];
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
