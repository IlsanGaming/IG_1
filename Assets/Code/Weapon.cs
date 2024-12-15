using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        instace= this;
    }

    void OnEnable()
    {

    }
    // Update is called once per frame
    void Update()
    {
        count = data.count[level];
        speed = data.speed[level];
        damage = playerData.damage[level];
        switch (id)
        {
            case 0:
                RotateIndependentOfScale();
                break;
            case 1:
                timer += Time.deltaTime;
                if(timer>speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
            default:
                break;
        }
        if(Input.GetButtonDown("Jump"))
        {
            level++;
            Init();
        }

    }
    public void Init()
    {
        switch(id)
        {
            case 0:
                Batch();
                break;
            default:
                break;
        }
    }
    void Batch()
    {
        for(int index=0;index<count;index++)
        {
            Transform Melee;
            if(index<transform.childCount)
            {
                Melee=transform.GetChild(index);
            }
            else
            {
                Melee= GameManager.instance.pool.Get(PoolManager.PoolType.Melee).transform;
            }
            Melee.parent=transform;
            Melee.localPosition= Vector3.zero;
            Melee.localRotation= Quaternion.identity;
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            Melee.Rotate(rotVec);
            Melee.Translate(Melee.up * 1.5f, Space.World);
            Melee.GetComponent<Bullet>().Init(damage, -1,Vector3.zero);//-1 is Infinity Per
        }
    }
    // 부모의 scale 부호를 무시하고 회전
    void RotateIndependentOfScale()
    {
        // 부모의 Scale X 부호를 가져오기
        float scaleFactor = Mathf.Sign(transform.lossyScale.x);

        // 회전 방향을 Scale 부호와 무관하게 고정
        transform.Rotate(Vector3.back * speed * scaleFactor * Time.deltaTime);
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;
        Vector3 targetPos=player.scanner.nearestTarget.position;
        Vector3 dir=targetPos-transform.position;
        dir = dir.normalized;

        Transform bullet= GameManager.instance.pool.Get(PoolManager.PoolType.Bullet).transform;
        bullet.position= transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up,dir);
        bullet.GetComponent<Bullet>().Init(damage,count, dir);
    }
}
