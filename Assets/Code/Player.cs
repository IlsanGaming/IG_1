using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("# Player Object(Do not Touch!)")]
    public float damage;
    public float critical;
    public float cool;
    public float armor;
    public float health;
    public float healthRegen;
    public float duration;
    public float speed;
    public float skill1cool;
    public float skill1length;
    public float skill1count;
    public float skill1damage;
    public float skill2cool;
    public float skill2length;
    public float skill2count;
    public float skill2damage;
    public float skill3cool;
    public float skill3length;
    public float skill3count;
    public float skill3damage;
    public float skill4cool;
    public float skill4length;
    public float skill4count;
    public float skill4damage;
    public float skill5cool;
    public float skill5length;
    public float skill5count;
    public float skill5damage;


    public Vector2 inputVec;
    public PlayerData data;
    public static Player instance;
    Transform trans;
    Rigidbody2D rigid;
    public Animator anim;
    public Scanner scanner;
    // Start is called before the first frame update
    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        scanner = GetComponent<Scanner>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void LateUpdate()
    {
        GetStat();
    }
    public void GetStat()
    {
         damage = data.damage[GameManager.instance.Gamelevel];
         critical = data.critical[GameManager.instance.Gamelevel];
         cool = data.cool[GameManager.instance.Gamelevel];
         armor= data.armor[GameManager.instance.Gamelevel];
         health = data.health[GameManager.instance.Gamelevel];
         healthRegen = data.healthRegen[GameManager.instance.Gamelevel];
         duration= data.duration[GameManager.instance.Gamelevel];
         speed = data.speed[GameManager.instance.Gamelevel];
         skill1cool= data.skill1cool[GameManager.instance.Gamelevel];
         skill1length= data.skill1length[GameManager.instance.Gamelevel];
         skill1count= data.skill1count[GameManager.instance.Gamelevel];
         skill1damage= data.skill1damage[GameManager.instance.Gamelevel];
         skill2cool= data.skill2cool[GameManager.instance.Gamelevel];
         skill2length= data.skill2length[GameManager.instance.Gamelevel];
         skill2count= data.skill2count[GameManager.instance.Gamelevel];
         skill2damage= data.skill2damage[GameManager.instance.Gamelevel];
         skill3cool = data.skill3cool[GameManager.instance.Gamelevel];
         skill3length = data.skill3length[GameManager.instance.Gamelevel];
         skill3count = data.skill3count[GameManager.instance.Gamelevel];
         skill3damage = data.skill3damage[GameManager.instance.Gamelevel];
         skill4cool = data.skill4cool[GameManager.instance.Gamelevel];
         skill4length = data.skill4length[GameManager.instance.Gamelevel];
         skill4count = data.skill4count[GameManager.instance.Gamelevel];
         skill4damage = data.skill4damage[GameManager.instance.Gamelevel];
         skill5cool = data.skill5cool[GameManager.instance.Gamelevel];
         skill5length = data.skill5length[GameManager.instance.Gamelevel];
         skill5count = data.skill5count[GameManager.instance.Gamelevel];
         skill5damage = data.skill5damage[GameManager.instance.Gamelevel];
    }
    void Move()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec); // 새로운 위치로 이동
        anim.SetBool("1_Move", inputVec !=Vector2.zero);

        float scaleX;
        // 수평 이동 입력에 따라 플레이어 스프라이트를 반전
        if (inputVec.x >= -1 && inputVec.x < 0)
        {
            scaleX = 1;
            trans.localScale = new Vector3(scaleX, trans.localScale.y, trans.localScale.z);
        }
        else if (inputVec.x <= 1 && inputVec.x > 0)
        {
            scaleX = -1;
            trans.localScale = new Vector3(scaleX, trans.localScale.y, trans.localScale.z);
        }
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
