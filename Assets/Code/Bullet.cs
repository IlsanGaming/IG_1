using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    public WeaponData data;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Init(float damage,int per,Vector3 dir)
    {
        this.damage = Player.instance.damage;
        this.per = data.per[GameManager.instance.Gamelevel];
        // 관통 가능 횟수가 0 이상일 경우
        if (per >= 0)
        {
            // 지정된 방향으로 속도 설정
            rigid.velocity = dir * data.bulletspeed[GameManager.instance.Gamelevel];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        per--;
        if(per==0)
        {
            rigid.velocity=Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
