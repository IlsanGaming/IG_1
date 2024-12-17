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
        // ���̵��� �ִ�ġ�� ���� �ʵ��� ����
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
        if (!isLive) // ������ ��Ȱ��ȭ ���¸� �������� ����
            return;

        exp++;

        // �ִ� ���� ���� �� ó��
        if (Player.instance.playerlevel >= Player.instance.maxplayerlevel)
        {
            Debug.Log("�ִ� ������ �����߽��ϴ�.");
            return;
        }

        // ����ġ Ȯ�� �� ������ ó��
        while (exp >= nextExp[Mathf.Min(Player.instance.playerlevel, nextExp.Length - 1)])
        {
            exp -= nextExp[Mathf.Min(Player.instance.playerlevel, nextExp.Length - 1)]; // �ʰ� ����ġ ����
            Player.instance.playerlevel++; // ���� ����

            Debug.Log("������! ���� ���� : " + Player.instance.playerlevel);

            // �ִ� ���� Ȯ��
            if (Player.instance.playerlevel >= Player.instance.maxplayerlevel)
            {
                exp = 0; // �ִ� ���� ���� �� ����ġ �ʱ�ȭ
                Debug.Log("�ִ� ���� ����. ����ġ �ʱ�ȭ.");
                break;
            }
        }

        // ���� ����ġ ���� ���
        Debug.Log("���� ����ġ : " + exp);
        Debug.Log("���� ������ �ʿ� ����ġ : " + nextExp[Mathf.Min(Player.instance.playerlevel, nextExp.Length - 1)]);
    }


    public void GameOver()
    {

    }
}
