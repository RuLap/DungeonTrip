using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    private Animator animator;
    private string[] idleAnimations = { "UpIdle", "LeftIdle", "DownIdle", "RightIdle" };
    private AudioSource walk;
    [SerializeField]
    private AudioClip sound;
    void Start()
    {
        walk = GetComponentInChildren<AudioSource>();
        walk.clip = sound;
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        var curState = animator.GetCurrentAnimatorStateInfo(0);
        if(curState.IsName("UpIdle") || curState.IsName("LeftIdle") || curState.IsName("DownIdle") || curState.IsName("RightIdle"))
        {
            walk.Stop();
        }
        else
        {
            if (!walk.isPlaying)
            {
                walk.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResetIdle();
            animator.SetTrigger("Up");
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.ResetTrigger("Up");
            animator.SetTrigger("UpIdle");
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ResetIdle();
            animator.SetTrigger("Left");
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.ResetTrigger("Left");
            animator.SetTrigger("LeftIdle");
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ResetIdle();
            animator.SetTrigger("Down");
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.ResetTrigger("Down");
            animator.SetTrigger("DownIdle");
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ResetIdle();
            animator.SetTrigger("Right");
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.ResetTrigger("Right");
            animator.SetTrigger("RightIdle");
        }
    }

    /// <summary>
    /// Сбрасывает отметку с анимации бездействия
    /// </summary>
    private void ResetIdle()
    {
        for (int i = 0; i < idleAnimations.Length; i++)
        {
            animator.ResetTrigger(idleAnimations[i]);
        }
    }
}
