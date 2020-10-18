using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject player;
    private Animator playerAnim;
    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        var curState = playerAnim.GetCurrentAnimatorStateInfo(0);
        if(curState.IsName("UpMove") || curState.IsName("UpIdle"))
        {
            animator.SetTrigger("UpAttack");
        }
        else if (curState.IsName("LeftMove") || curState.IsName("LeftIdle"))
        {
            animator.SetTrigger("LeftAttack");
        }
        else if (curState.IsName("DownMove") || curState.IsName("DownIdle"))
        {
            animator.SetTrigger("DownAttack");
        }
        else if (curState.IsName("RightMove") || curState.IsName("RightIdle"))
        {
            animator.SetTrigger("RightAttack");
        }
    }
}
