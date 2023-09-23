using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MsgDisp : MonoBehaviour
{

    public Text textMsg;
    int msgLen;
    public bool flagDisplay = false;
    string message;

    float nextTime = 0;

    void Start()
    {
        textMsg.text = null;
    }

    void Update()
    {
        if(flagDisplay && Time.time > nextTime)
        {
            if (msgLen < message.Length)
                textMsg.text += message[msgLen++];
            nextTime = Time.time + 0.02f;
        }
    }

    public void ShowMessage(string msg)
    {
        message = msg;
        msgLen = 0;

    }
}
