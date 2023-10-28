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
            animator.SetInteger("State", 0);    // �ҋ@
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetInteger("State", 1);    // ���U��
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetInteger("State", 2);    // �x��
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetInteger("State", 3);    // �I���
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("SleepTrigger");  // ����
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("SitTrigger");  // ����
        }
    }
}
