using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public Button buttonGame;
    public GameObject buttonGrid;
    public Button buttonGoo;
    public Button buttonChoki;
    public Button buttonPar;

    public JanKen janken;

    void Update()
    {
        setActiveGameBtn();
    }

    void setActiveGameBtn()
    {
        if (!janken.GetFlagJanken())
        {
            buttonGame.gameObject.SetActive(true);
        }
        else if (janken.GetModeJanken() == 1)
        {
            buttonGoo.gameObject.SetActive(true);
            buttonChoki.gameObject.SetActive(true);
            buttonPar.gameObject.SetActive(true);
        }
    }

    public void ClickStart()
    {
        buttonGame.gameObject.SetActive(false);
        janken.SetFlagJanken(true);
        buttonGrid.SetActive(true);
    }

    public void ClickGOO()
    {
        janken.WaitInput("GOO");
        SetActiveFalse();
    }
    public void ClickCHOKI()
    {
        janken.WaitInput("CHOKI");
        SetActiveFalse();
    }
    public void ClickPAR()
    {
        janken.WaitInput("PAR");
        SetActiveFalse();
    }

    void SetActiveFalse()
    {
        buttonGoo.gameObject.SetActive(false);
        buttonChoki.gameObject.SetActive(false);
        buttonPar.gameObject.SetActive(false);
    }
}