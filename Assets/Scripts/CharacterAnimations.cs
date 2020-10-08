﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CharacterAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    string state;
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Move", true);
        }
        if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Move", false);
        }
    }
    private void FixedUpdate()
    {
        float Angle = ViewingAngle();
        if (Angle >= 45 && Angle <= 135 && state != "Left")
        {
            animator.Play("BodyIdleLeft");
            state = "Left";
        }
        else if (Angle >= 135 && Angle <= 225 && state != "Up")
        {
            animator.Play("BodyIdleUp");
            state = "Up";
        }
        else if (Angle >= 225 && Angle <= 315 && state != "Right")
        {
            animator.Play("BodyIdleRight");
            state = "Right";
        }
        else if (state != "Down" &&((Angle>=315&&Angle<=360)||(Angle>=0&&Angle<=45)))
        {
            animator.Play("BodyIdleDown");
            state = "Down";
        }
    }
    float ViewingAngle()
    {
        UnityEngine.Vector2 direction = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float value = (float)((Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg));
        if (value < 0) value += 360f;
        Debug.Log(value);
        return value;
    }
}
