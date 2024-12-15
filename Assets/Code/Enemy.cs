using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float health;
    public float speed;
    public int id;
    public float skillcool;
    public float skilllength;
    public float skillcount;
    public float skilldamage;
    public float spawnTime;
    bool isLive;

    public Rigidbody2D target;
    public EnemyData data;
    public static Enemy instance;
    public Animator anim;


    Collider2D coll;
    Rigidbody2D rigid;
    Transform trans;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        trans= GetComponent<Transform>();
        coll = GetComponent<Collider2D>();
        instance = this;
    }
    void OnEnable()
    {
        target = Player.instance.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        anim.SetBool("isDeath",false);
        anim.SetBool("1_Move", true);
        damage = data.damage[GameManager.instance.level];
        health= data.health[GameManager.instance.level];
        speed= data.speed[GameManager.instance.level];
        skillcool = data.skillcool[GameManager.instance.level];
        skilllength = data.skilllength[GameManager.instance.level];
        skillcount = data.skillcount[GameManager.instance.level];
        skilldamage = data.skilldamage[GameManager.instance.level];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }
    void LateUpdate()
    {
        // target의 위치와 Enemy의 위치를 비교하여 방향 설정
        float direction = target.position.x - rigid.position.x;

        if (Mathf.Abs(direction) > 0.2f) // 일정 범위를 벗어난 경우만 처리
        {
            trans.localScale = new Vector3(direction < 0 ? Mathf.Abs(trans.localScale.x) : -Mathf.Abs(trans.localScale.x),
                                            trans.localScale.y,
                                            trans.localScale.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Bullet"))
        {
            return;
        }
        health-=collision.GetComponent<Bullet>().damage;
        if(health > 0)
        {

        }
        else
        {
            Dead();
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
