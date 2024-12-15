using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime;
    [Header("# Game Info")]
    public int level;

    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            maxGameTime += 10;
            gameTime = 0;
            level++;
        }
    }
}
