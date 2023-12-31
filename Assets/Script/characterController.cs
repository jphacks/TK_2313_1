using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    Animator animator;
    int sitNum = 0;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetInteger("State", -1);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetInteger("State", 0);    // 待機
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetInteger("State", 1);    // 手を振る
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetInteger("State", 2);    // 踊る
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetInteger("State", 3);    // 終わり
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("SleepTrigger");  // 座る
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("SitTrigger");  // 座る
        }
    }
}
