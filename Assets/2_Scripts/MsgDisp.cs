using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MsgDisp : MonoBehaviour
{
    public Image image;
    public Text textMsg;

    int msgLen;
    public bool flagDisplay = false;
    string message;
    float nextTime = 0;
    public float waitDelay;

    void Start()
    {
        textMsg.text = null;
    }

    void Update()
    {

        if (flagDisplay)
        {
            if (msgLen < message.Length)    // 작성 중이면
            {
                if (Time.time > nextTime)
                {
                    textMsg.text += message[msgLen++];
                    nextTime = Time.time + 0.02f;
                }
            }
            else  // 다 썼으면
            {
                waitDelay += Time.deltaTime;    // 기다리기
                if (waitDelay > 1 + message.Length / 4)
                {
                    flagDisplay = false;
                    image.gameObject.SetActive(false);
                }
            }
        }
    }

    public void setActiveTure()
    {
        flagDisplay = true;
        image.gameObject.SetActive(true);
    }
    public void ShowMessage(string msg)
    {
        textMsg.text = null;
        message = msg;
        msgLen = 0;
        waitDelay = 0;
    }
}
