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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
