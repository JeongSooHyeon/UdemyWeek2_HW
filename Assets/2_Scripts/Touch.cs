using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    public AudioClip voice3;
    
    private Animator animator;
    private AudioSource univoice;

    public MsgDisp message;

    // ��� ������Ʈ�� ID ���
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");

    private void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        // ��� ���� ������ ��� �������� �˻�
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
            animator.SetBool("Motion_Idle", true);
        else
            animator.SetBool("Motion_Idle", false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitobj = hit.collider.gameObject;
                if (hitobj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    message.flagDisplay = true;
                    message.ShowMessage("�ȳ�!\n���õ� ������ �����غ���!");
                }
                else if (hitobj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    message.flagDisplay = true;
                    message.ShowMessage("��!");
                }
                else if(hitobj.tag == "Arm")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice3;
                    univoice.Play();
                    message.flagDisplay = true;
                    message.ShowMessage("���� " + DateTime.Now.Date.ToString("G") + "������~!");
                }
                Debug.Log(hitobj.tag);
            }
        }
    }
}
