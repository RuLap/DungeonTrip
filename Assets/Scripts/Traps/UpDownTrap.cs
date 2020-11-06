using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отображает состояние ловушки
/// </summary>
public enum TrapState
{
    down,
    middle,
    up
}
public class UpDownTrap : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer sr;
    private TrapState state;
    private BoxCollider2D _collider;
    private Light light;

    private int damage = 10;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        light = GetComponentInChildren<Light>();
        sr = GetComponent<SpriteRenderer>();
        state = TrapState.down;
        StartCoroutine(ChangeState());
    }

    /// <summary>
    /// Меняет состояние ловушки с временной задержкой
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeState()
    {
        while (true)
        {
            if (state == TrapState.down)
            {
                state = TrapState.middle;
                _collider.enabled = false;
                light.enabled = false;
            }
            else if (state == TrapState.middle)
            {
                state = TrapState.up;
                _collider.enabled = true;
                light.enabled = true;
            }
            else
            {
                state = TrapState.down;
                _collider.enabled = false;
                light.enabled = false;
            }
            sr.sprite = sprites[(int)state];
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    /// <summary>
    /// При касании с чем либо проверить на возможность нанести урон
    /// </summary>
    /// <param name="collision">Объект соприкосновения</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckForDamage(collision);
    }

    /// <summary>
    /// Проверяет объект касания на возможность нанести урон
    /// </summary>
    /// <param name="collision">Объект соприкосновения</param>
    private void CheckForDamage(Collider2D collision)
    {
        if (state == TrapState.up)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.ApplyDamage(damage);
            }
            else if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.ApplyDamage(damage);
            }
        }
    }
}
