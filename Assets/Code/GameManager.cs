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
        if (!isLive) // ������ ��Ȱ��ȭ ���¸� �������� ����
            return;

        exp += gainexp;

        // ����ġ�� ���� ������ �䱸ġ�� �����ϸ� ������ ó��
        if (exp > nextExp[Mathf.Min(Gamelevel, nextExp.Length - 1)])
        {
            Player.instance.playerlevel++; // ���� ����
            exp = nextExp[Mathf.Min(Gamelevel, nextExp.Length - 1)] - exp;
            Debug.Log("���� ���� : " + Player.instance.playerlevel);
            Debug.Log("�ʿ� ����ġ" + nextExp[Player.instance.playerlevel]);
        }
    }
}
