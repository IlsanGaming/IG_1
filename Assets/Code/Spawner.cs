using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public float timer;
    public EnemyData[] data;
    public SpawnChancesData spawnChancesData; // 스폰 확률 데이터 (ScriptableObject)
    // Start is called before the first frame update
    void Awake()
    {
        spawnPoint=GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 타이머 증가
        timer += Time.deltaTime;

        // 데이터 범위 확인
        if (GameManager.instance.level < data.Length)
        {
            EnemyData currentData = data[GameManager.instance.level];

            if (GameManager.instance.level < currentData.spawnTime.Length)
            {
                // 타이머가 현재 레벨의 스폰 타임을 초과하면 적 스폰
                if (timer > currentData.spawnTime[GameManager.instance.level])
                {
                    Spawn();
                    timer = 0; // 타이머 초기화
                }
            }
        }
    }

    void Spawn()
    {
        int level = GameManager.instance.level;

        // 현재 레벨의 스폰 확률 가져오기
        if (level < spawnChancesData.spawnChancesList.Count)
        {
            var spawnChances = spawnChancesData.spawnChancesList[level].chances;

            // 적 스폰
            PoolManager.PoolType[] enemyTypes = { PoolManager.PoolType.Enemy1, PoolManager.PoolType.Enemy2, PoolManager.PoolType.Enemy3 };
            int selectedIndex = GetRandomEnemyIndex(spawnChances);

            if (selectedIndex != -1 && selectedIndex < enemyTypes.Length)
            {
                GameObject enemy = GameManager.instance.pool.Get(enemyTypes[selectedIndex]);
                enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            }
        }
    }

    int GetRandomEnemyIndex(float[] chances)
    {
        float randomValue = Random.Range(0f, 1f); // 0.0 ~ 1.0
        float cumulative = 0f;

        for (int i = 0; i < chances.Length; i++)
        {
            cumulative += chances[i];
            if (randomValue <= cumulative)
                return i; // 선택된 적 인덱스
        }

        return -1; // 선택 실패
    }
}
