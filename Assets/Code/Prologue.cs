using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    public GameObject epl;
    public GameObject ep1;
    public GameObject prologueFrame;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject p9;
    public GameObject p10;
    public GameObject p11;
    public GameObject p12;
    public GameObject p13;
    public GameObject p14;
    public GameObject p15;
    public GameObject p16;
    public GameObject p17;
    public GameObject p18;
    public GameObject p19;
    public GameObject p20;
    public GameObject p21;
    public GameObject p22;

    public void show2()
    {
        p1.SetActive(false);
        p2.SetActive(true);
    }
    public void show3()
    {
        p2.SetActive(false);
        p3.SetActive(true);
    }
    public void show4()
    {
        p3.SetActive(false);
        p4.SetActive(true);
    }
    public void show5()
    {
        p4.SetActive(false);
        p5.SetActive(true);
    }
    public void show6()
    {
        p5.SetActive(false);
        p6.SetActive(true);
    }
    public void show7()
    {
        p6.SetActive(false);
        p7.SetActive(true);
    }
    public void show8()
    {
        p7.SetActive(false);
        p8.SetActive(true);
    }
    public void show9()
    {
        p8.SetActive(false);
        p9.SetActive(true);
    }
    public void show10()
    {
        p9.SetActive(false);
        p10.SetActive(true);
    }
    public void show11()
    {
        p10.SetActive(false);
        p11.SetActive(true);
    }
    public void show12()
    {
        p11.SetActive(false);
        p12.SetActive(true);
    }
    public void show13()
    {
        p12.SetActive(false);
        p13.SetActive(true);
    }
    public void show14()
    {
        p13.SetActive(false);
        p14.SetActive(true);
    }
    public void show15()
    {
        p14.SetActive(false);
        p15.SetActive(true);
    }
    public void show16()
    {
        p15.SetActive(false);
        p16.SetActive(true);
    }
    public void show17()
    {
        p16.SetActive(false);
        p17.SetActive(true);
    }
    public void show18()
    {
        p17.SetActive(false);
        p18.SetActive(true);
    }
    public void show19()
    {
        p18.SetActive(false);
        p19.SetActive(true);
    }
    public void show20()
    {
        p19.SetActive(false);
        p20.SetActive(true);
    }
    public void show21()
    {
        p20.SetActive(false);
        p21.SetActive(true);
    }
    public void show22()
    {
        p21.SetActive(false);
        p22.SetActive(true);
    }
    
    public void GameStart()
    {
        p22.SetActive(false);
        prologueFrame.SetActive(false);
        GameManager.instance.isLive = true;
        AudioManager.instance.PlayBgm(true);
    }
    
    /*
    public void GameStart()
    {
        p22.SetActive(false);
        prologueFrame.SetActive(false);
        epl.SetActive(true);
        ep1.SetActive(true);
    }
    */
}
