using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public float timer;
    public EnemyData[] data;
    public SpawnChancesData spawnChancesData;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        timer += Time.deltaTime;

        if (GameManager.instance.Gamelevel < data.Length)
        {
            EnemyData currentData = data[GameManager.instance.Gamelevel];

            if (GameManager.instance.Gamelevel < currentData.spawnTime.Length)
            {
                if (timer > currentData.spawnTime[GameManager.instance.Gamelevel])
                {
                    Spawn();
                    timer = 0;
                }
            }
        }
    }

    void Spawn()
    {
        int level = GameManager.instance.Gamelevel;

        if (level < spawnChancesData.spawnChancesList.Count)
        {
            var spawnChances = spawnChancesData.spawnChancesList[level].chances;

            // 적 타입 배열을 5개로 확장
            PoolManager.PoolType[] enemyTypes = {
                PoolManager.PoolType.Enemy1,
                PoolManager.PoolType.Enemy2,
                PoolManager.PoolType.Enemy3,
                PoolManager.PoolType.Enemy4,
                PoolManager.PoolType.Enemy5
            };

            if (spawnChances.Length != enemyTypes.Length)
            {
                Debug.LogError("Spawn chances length does not match the number of enemy types.");
                return;
            }

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
        if (chances == null || chances.Length == 0)
        {
            Debug.LogError("Spawn chances are not defined or empty.");
            return -1;
        }

        float totalChance = 0f;
        foreach (var chance in chances)
            totalChance += chance;

        if (Mathf.Approximately(totalChance, 0f))
        {
            Debug.LogError("Total spawn chances cannot be zero.");
            return -1;
        }

        float randomValue = Random.Range(0f, totalChance);
        float cumulative = 0f;

        for (int i = 0; i < chances.Length; i++)
        {
            cumulative += chances[i];
            if (randomValue <= cumulative)
                return i;
        }

        return -1;
    }
}
