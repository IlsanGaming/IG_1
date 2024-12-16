using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime;
    [Header("# Game level")]
    public int Gamelevel;
    [Header("# Exp")]
    public int exp;
    public int[] nextExp;
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    public GameData data;

    void Awake()
    {
        instance = this;
        nextExp = data.nextexp;
    }
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            maxGameTime += 10;
            gameTime = 0;
            Gamelevel++;
        }
    }
    public void GetExp(int gainexp)
    {
        if (!isLive) // 게임이 비활성화 상태면 동작하지 않음
            return;

        exp += gainexp;

        // 경험치가 다음 레벨업 요구치를 충족하면 레벨업 처리
        if (exp > nextExp[Mathf.Min(Gamelevel, nextExp.Length - 1)])
        {
            Player.instance.playerlevel++; // 레벨 증가
            exp = nextExp[Mathf.Min(Gamelevel, nextExp.Length - 1)] - exp;
            Debug.Log("현재 레벨 : " + Player.instance.playerlevel);
            Debug.Log("필요 경험치" + nextExp[Player.instance.playerlevel]);
        }
    }
}
