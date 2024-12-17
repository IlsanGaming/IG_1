using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public static EnemyBullet instance;
    public float damage;

    public EnemyBulletData data;
    Rigidbody2D rigid;

    void Awake()
    {
        instance = this;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        damage = data.damage[GameManager.instance.Gamelevel];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

            rigid.velocity = Vector2.zero;    // 속도 초기화
            gameObject.SetActive(false);     // 총알 비활성화
    }
}
