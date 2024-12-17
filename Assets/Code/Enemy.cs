using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using static PoolManager;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float maxspeed;
    public int id;
    public float skillcool;
    public float maxskillcool;
    public float skillspeed;
    public float spawnTime;
    public int exp;
    public bool isLive;
    public float stopDistance = 2f;

    public Rigidbody2D target;
    public EnemyData data;
    public static Enemy instance;
    public Animator anim;
    public bool isDamaged;


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
        target = GameManager.instance.bus.GetComponent<Rigidbody2D>();
        isLive = true;
        isDamaged = false;
        coll.enabled = true;
        rigid.simulated = true;
        skillcool = 0;
        anim.SetBool("isDeath",false);
        anim.SetBool("1_Move", true);
        speed= data.speed[GameManager.instance.Gamelevel];
        maxskillcool = data.skillcool[GameManager.instance.Gamelevel];
        skillspeed = data.skillspeed[GameManager.instance.Gamelevel];
        spawnTime= data.spawnTime[GameManager.instance.Gamelevel];
        exp = data.exp[GameManager.instance.Gamelevel];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        Move();
    }
    void Move()
    {
        // "isDamaged" 상태에서 이동하지 않음
        if (!isLive || isDamaged)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; // 추가로 velocity 초기화 방지
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
        if(collision.gameObject.tag=="Bullet")
        {
            speed-=collision.GetComponent<Bullet>().slow;
            StartCoroutine(knockBack());
            if(speed > 0)
            {
                anim.SetTrigger("3_Damaged");
                AudioManager.instance.PlaySfx(AudioManager.Sfx.EnemyHit);
            }
            else
            {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            anim.SetTrigger("4_Death");
            DropItem();
            Invoke("Dead",0.8f);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.EnemyDead);
            }
        }
        else if(collision.gameObject.tag=="Player")
        {
            anim.SetTrigger("2_Attack");
        }
    }
    void Createbullet(PoolType type, Vector3 offset)
    {
        GameObject bullet = GameManager.instance.pool.Get(type);
        if (bullet == null)
        {
            Debug.LogError($"Failed to create bullet of type {type}");
            return;
        }

        Vector3 dirVec = target.transform.position - transform.position;
        bullet.transform.position = transform.position + offset;
        bullet.GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * skillspeed, ForceMode2D.Impulse);

        Debug.Log($"Bullet created at {bullet.transform.position} with direction {dirVec.normalized}");
    }

    IEnumerator knockBack()
    {
        isDamaged = true;

        // 기존 속도 초기화
        rigid.velocity = Vector2.zero;

        // 넉백 방향 계산
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = (transform.position - playerPos).normalized;

        // 넉백 힘 적용
        float knockBackForce = data.lightness[GameManager.instance.Gamelevel];
        Debug.Log($"Knockback Direction: {dirVec}, Force: {knockBackForce}");
        rigid.AddForce(dirVec * knockBackForce, ForceMode2D.Impulse);

        // 대기 시간
        yield return new WaitForSeconds(data.time[GameManager.instance.Gamelevel]);

        isDamaged = false;
    }
    void DropItem()
    {
        int ran = Random.Range(0, 10);
        GameObject item = null;

        if (ran < 8)
        {
            Debug.Log("Not Item");
        }
        else if (ran < 10)
        {
            Debug.Log("Attempting to create itemHealth...");
            item = GameManager.instance.pool.Get(PoolManager.PoolType.part);
        }

        if (item != null)
        {
            item.transform.position = transform.position;
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
