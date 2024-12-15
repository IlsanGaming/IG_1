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
    public int exp;
    public bool isLive;

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
        target = Player.instance.GetComponent<Rigidbody2D>();
        isLive = true;
        isDamaged = false;
        coll.enabled = true;
        rigid.simulated = true;
        anim.SetBool("isDeath",false);
        anim.SetBool("1_Move", true);
        damage = data.damage[GameManager.instance.Gamelevel];
        health= data.health[GameManager.instance.Gamelevel];
        speed= data.speed[GameManager.instance.Gamelevel];
        skillcool = data.skillcool[GameManager.instance.Gamelevel];
        skilllength = data.skilllength[GameManager.instance.Gamelevel];
        skillcount = data.skillcount[GameManager.instance.Gamelevel];
        skilldamage = data.skilldamage[GameManager.instance.Gamelevel];
        spawnTime= data.spawnTime[GameManager.instance.Gamelevel];
        exp = data.exp[GameManager.instance.Gamelevel];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        // "isDamaged" ���¿��� �̵����� ����
        if (!isLive || isDamaged)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; // �߰��� velocity �ʱ�ȭ ����
    }
    void LateUpdate()
    {
        // target�� ��ġ�� Enemy�� ��ġ�� ���Ͽ� ���� ����
        float direction = target.position.x - rigid.position.x;

        if (Mathf.Abs(direction) > 0.2f) // ���� ������ ��� ��츸 ó��
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
        StartCoroutine(knockBack());
        if(health > 0)
        {
            anim.SetTrigger("3_Damaged");
        }
        else
        {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            anim.SetTrigger("4_Death");
            GameManager.instance.GetExp(1);
            Invoke("Dead",0.8f);
        }
    }
    IEnumerator knockBack()
    {
        isDamaged = true;

        // ���� �ӵ� �ʱ�ȭ
        rigid.velocity = Vector2.zero;

        // �˹� ���� ���
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = (transform.position - playerPos).normalized;

        // �˹� �� ����
        float knockBackForce = data.lightness[GameManager.instance.Gamelevel];
        Debug.Log($"Knockback Direction: {dirVec}, Force: {knockBackForce}");
        rigid.AddForce(dirVec * knockBackForce, ForceMode2D.Impulse);

        // ��� �ð�
        yield return new WaitForSeconds(data.time[GameManager.instance.Gamelevel]);

        isDamaged = false;
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
