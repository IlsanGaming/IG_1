using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Enum 정의
    public enum PoolType
    {
        Enemy1,//0
        Enemy2,//1
        Enemy3,//2
        Enemy4,//3
        Enemy5,//4
        Enemy6,//5
        Enemy7,//6
        Enemy8,//7
        Enemy9,//8
        Enemy10,//9
        Melee,//10
        Bullet,
        Explosion,
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
