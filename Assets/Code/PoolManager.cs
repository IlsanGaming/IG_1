using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    // Enum 정의
    public enum PoolType
    {
        Enemy1,//0
        Enemy2,//1
        Enemy3,//2
        Enemy4,//3
        Enemy5,//4
        Melee,//5
        Bullet1,//6
        Explosion,//7
        part,//8
        heal,//9
        jam,//10
        enemyBullet1,//11
        // 필요에 따라 추가
    }

    public GameObject[] prefabs; // 인스펙터에서 초기화
    public Dictionary<PoolType, List<GameObject>> pools;

    void Awake()
    {
        instance = this;
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
    public void ReturnToPool(GameObject item, PoolType type)
    {
        item.SetActive(false);
        pools[type].Add(item);
    }

}
