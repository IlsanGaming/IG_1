using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epilogue : MonoBehaviour
{
    public GameObject prologueFrame;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject endsc;

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
    public void showEnding()
    {
        p8.SetActive(false);
        prologueFrame.SetActive(false);
        endsc.SetActive(true);
    }
}
