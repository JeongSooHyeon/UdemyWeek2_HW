using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanKen : MonoBehaviour
{
    bool flagJanken = false;    // ����� ���� �÷���
    int modeJanken = 0;         // ���� ���

    public AudioClip voiceStart;
    public AudioClip voicePon;
    public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;

    const int JANKEN = -1;
    const int GOO = 0;
    const int CHOKI = 1;
    const int PAR = 2;
    const int DRAW = 3;
    const int WIN = 4;
    const int LOOSE = 5;

    private Animator animator;
    private AudioSource univoice;

    int myHand;
    int unityHand;
    int flagResult;
    int[,] tableResult = new int[3, 3];

    float waitDelay;



    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();

        // ��� ���̺� �̸� ���� [����Ƽ¯, �÷��̾�]
        tableResult[GOO, GOO] = DRAW;
        tableResult[GOO, CHOKI] = WIN;
        tableResult[GOO, PAR] = LOOSE;
        tableResult[CHOKI, GOO] = LOOSE;
        tableResult[CHOKI, CHOKI] = DRAW;
        tableResult[CHOKI, PAR] = WIN;
        tableResult[PAR, GOO] = WIN;
        tableResult[PAR, CHOKI] = LOOSE;
        tableResult[PAR, PAR] = DRAW;
    }

    void Update()
    {        
        // ����� �����̸�
        if (flagJanken)
        {
            // ���� ��忡 ����
            switch (modeJanken)
            {
                case 0: // ����� ����
                    UnityChanAction(JANKEN);
                    modeJanken++;
                    break;

                case 1: // �÷��̾� �Է� ���
                    // �ִϸ��̼� �ʱ�ȭ
                    animator.SetBool("Janken", false);
                    animator.SetBool("Aiko", false);
                    animator.SetBool("Goo", false);
                    animator.SetBool("Choki", false);
                    animator.SetBool("Par", false);
                    animator.SetBool("Win", false);
                    animator.SetBool("Loose", false);
                    break;

                case 2: // ����
                    flagResult = JANKEN;
                    // ����Ƽ¯�� ���� �������� ����
                    unityHand = Random.Range(GOO, PAR + 1);
                    // ����Ƽ¯ �׼�
                    UnityChanAction(unityHand);
                    // ���
                    flagResult = tableResult[unityHand, myHand];
                    modeJanken++;
                    break;

                case 3: // ���
                    // �ణ�� �ð� ����
                    waitDelay += Time.deltaTime;
                    if(waitDelay > 1.5f)
                    {
                        // ����Ƽ¯ ��� �׼�
                        UnityChanAction(flagResult);

                        waitDelay = 0;
                        modeJanken++;
                    }
                    break;

                default:    // ���� ������ �ʱ�ȭ
                    flagJanken = false;
                    modeJanken = 0; // ����� ��ư ������
                    break;
            }
        }
    }

    public bool GetFlagJanken()
    {
        return flagJanken;
    }
    public void SetFlagJanken(bool flag)
    {
        flagJanken = flag;
    }
    public int GetModeJanken()
    {
        return modeJanken;
    }
    public void WaitInput(string choice)
    {
        switch (choice)
        {
            case "GOO":
                myHand = GOO;
                modeJanken++;
                break;

            case "CHOKI":
                myHand = CHOKI;
                modeJanken++;
                break;

            case "PAR":
                myHand = PAR;
                modeJanken++;
                break;
        }
    }


    // ����Ƽ¯�� �׼�
    void UnityChanAction(int act)   // �̺�Ʈ �Լ�
    {
        switch(act){
            case JANKEN:
                animator.SetBool("Janken", true);
                univoice.clip = voiceStart;
                break;

            case GOO:
                animator.SetBool("Goo", true);
                univoice.clip = voiceGoo;
                break;

            case CHOKI:
                animator.SetBool("Choki", true);
                univoice.clip = voiceChoki;
                break;

            case PAR:
                animator.SetBool("Par", true);
                univoice.clip = voicePar;
                break;

            case DRAW:
                animator.SetBool("Aiko", true);
                univoice.clip = voiceDraw;
                break;

            case WIN:
                animator.SetBool("Win", true);
                univoice.clip = voiceWin;
                break;

            case LOOSE:
                animator.SetBool("Loose", true);
                univoice.clip = voiceLoose;
                break;

        }
        univoice.Play();
    }
}