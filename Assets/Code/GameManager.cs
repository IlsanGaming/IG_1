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
    public int maxGamelevel;
    [Header("# Exp")]
    public int exp;
    public int[] nextExp;
    [Header("# Jam")]
    public int jam;
    public int MaxJam;
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    public GameData data;
    public GameObject bus;

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        if (!isLive)
        {
            return;
        }
    }
    void Update()
    {
        if (!isLive)
        {
            return;
        }
        SetGameDifference();
    }
    void SetGameDifference()
    {
        // 난이도가 최대치를 넘지 않도록 제한
        if (Gamelevel >= maxGamelevel)
        {
            Gamelevel = maxGamelevel;
            return;
        }
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = 0;
            Gamelevel++;
        }
    }
    public void GetExp()
    {
        if (!isLive) // 게임이 비활성화 상태면 동작하지 않음
            return;

        exp++;

        // 최대 레벨 도달 시 처리
        if (Player.instance.playerlevel >= Player.instance.maxplayerlevel)
        {
            Debug.Log("최대 레벨에 도달했습니다.");
            return;
        }

        // 경험치 확인 및 레벨업 처리
        while (exp >= nextExp[Mathf.Min(Player.instance.playerlevel, nextExp.Length - 1)])
        {
            exp -= nextExp[Mathf.Min(Player.instance.playerlevel, nextExp.Length - 1)]; // 초과 경험치 유지
            Player.instance.playerlevel++; // 레벨 증가

            Debug.Log("레벨업! 현재 레벨 : " + Player.instance.playerlevel);

            // 최대 레벨 확인
            if (Player.instance.playerlevel >= Player.instance.maxplayerlevel)
            {
                exp = 0; // 최대 레벨 도달 시 경험치 초기화
                Debug.Log("최대 레벨 도달. 경험치 초기화.");
                break;
            }
        }

        // 현재 경험치 상태 출력
        Debug.Log("현재 경험치 : " + exp);
        Debug.Log("다음 레벨업 필요 경험치 : " + nextExp[Mathf.Min(Player.instance.playerlevel, nextExp.Length - 1)]);
    }


    public void GameOver()
    {

    }
}
