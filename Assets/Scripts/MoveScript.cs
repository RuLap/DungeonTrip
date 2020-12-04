using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.position+=Vector3.forward*Time.fixedDeltaTime*speed;
    }
}
