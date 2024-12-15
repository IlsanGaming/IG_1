using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Enum 정의
    public enum PoolType
    {
        Enemy1,
        Enemy2,
        Enemy3,
        Enemy4,
        Enemy5,
        Enemy6,
        Enemy7,
        Enemy8,
        Enemy9,
        Enemy10,// 0
        Bullet,     // 1
        Explosion,  // 2
        // 필요에 따라 추가
    }

    public GameObject[] prefabs; // 인스펙터에서 초기화
    public Dictionary<PoolType, List<GameObject>> pools;

    void Awake()
    {
        pools = new Dictionary<PoolType, List<GameObject>>();

        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[(PoolType)i] = new List<GameObject>();
        }
    }

    public GameObject Get(PoolType type)
    {
        GameObject select = null;

        foreach (GameObject item in pools[type])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[(int)type], transform);
            pools[type].Add(select);
        }

        return select;
    }

    public void Clear(PoolType type)
    {
        foreach (GameObject item in pools[type])
        {
            item.SetActive(false);
        }
    }

    public void ClearAll()
    {
        foreach (var pool in pools)
        {
            foreach (GameObject item in pool.Value)
            {
                item.SetActive(false);
            }
        }
    }
}
