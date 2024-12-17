using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public GameObject main;
    public GameObject Prologue;
    public GameObject p1;

    public void OnClickGameStart()
    {
        main.SetActive(false);
        Prologue.SetActive(true);
        p1.SetActive(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }
    public void OnClickGameQuit()
    {
        Application.Quit();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }
}
