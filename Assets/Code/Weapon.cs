using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using static PoolManager;

public class Weapon : MonoBehaviour
{
    public static Weapon instace;
    public int id;
    public float damage;
    public int count;
    public float speed;

    public WeaponData data;
    public PlayerData playerData;
    public int level;

    float timer;
    Player player;
    void Awake()
    {
        player = GetComponentInParent<Player>();
        instace = this;
    }
    // Update is called once per frame
    void Update()
    {
        count = data.count[Player.instance.playerlevel];
        speed = data.speed[Player.instance.playerlevel];
        damage = playerData.damage[Player.instance.playerlevel];
        timer += Time.deltaTime;
        if (timer > speed)
        {
            timer = 0f;
            Fire();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Player.instance.playerlevel++;
        }

    }

    void Fire()
    {
        level = Player.instance.playerlevel;
        switch (level)
        {
            case 0:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero);
                break;
            case 1:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.right * 0.1f);
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.left * 0.1f);
                break;
            case 2:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.right * 0.1f);
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.right * 0.2f);
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.left * 0.1f);
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.left * 0.2f);
                break;
            case 3:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero);
                break;
            case 4:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero);
                break;
            case 5:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero);
                break;
            case 6:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero);
                break;
        }
    }
    void Createbullet(PoolType type, Vector3 offset)
    {
        if (player.scanner.nearestTarget == null)
        {
            Debug.LogWarning("No target found for Createbullet");
            return; // 타겟이 없으면 총알을 발사하지 않음
        }

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        if (GameManager.instance.pool == null)
        {
            Debug.LogError("PoolManager is not initialized");
            return;
        }

        Transform bullet = GameManager.instance.pool.Get(PoolManager.PoolType.Bullet1).transform;
        bullet.position = transform.position + offset;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir);
    }


}