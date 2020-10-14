using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечает за плавное движение камеры
/// </summary>
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float smoothing = 0.05f;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        if(transform.position != player.transform.position)
        {
            Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing);
        }
    }
}
