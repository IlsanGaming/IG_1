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

    private void OnEnable()
    {
        damage = Player.instance.damage;
        per = data.per[GameManager.instance.Gamelevel];
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        damage = Player.instance.damage;
        per = data.per[GameManager.instance.Gamelevel];
        if (per >= 0)
        {
            rigid.velocity = dir * data.bulletspeed[GameManager.instance.Gamelevel];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        per--;
        if (per == 0)
        {
            rigid.velocity = Vector2.zero;    // 속도 초기화
            gameObject.SetActive(false);     // 총알 비활성화
        }
    }


}
