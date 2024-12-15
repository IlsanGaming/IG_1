using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public float timer;
    public EnemyData[] data;
    public SpawnChancesData spawnChancesData; // ���� Ȯ�� ������ (ScriptableObject)
    // Start is called before the first frame update
    void Awake()
    {
        spawnPoint=GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ�̸� ����
        timer += Time.deltaTime;

        // ������ ���� Ȯ��
        if (GameManager.instance.level < data.Length)
        {
            EnemyData currentData = data[GameManager.instance.level];

            if (GameManager.instance.level < currentData.spawnTime.Length)
            {
                // Ÿ�̸Ӱ� ���� ������ ���� Ÿ���� �ʰ��ϸ� �� ����
                if (timer > currentData.spawnTime[GameManager.instance.level])
                {
                    Spawn();
                    timer = 0; // Ÿ�̸� �ʱ�ȭ
                }
            }
        }
    }

    void Spawn()
    {
        int level = GameManager.instance.level;

        // ���� ������ ���� Ȯ�� ��������
        if (level < spawnChancesData.spawnChancesList.Count)
        {
            var spawnChances = spawnChancesData.spawnChancesList[level].chances;

            // �� ����
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
                return i; // ���õ� �� �ε���
        }

        return -1; // ���� ����
    }
}
