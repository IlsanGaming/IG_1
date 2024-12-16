using System.Collections;
using System.Collections.Generic;
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

    public int playerlevel;

    public Vector2 inputVec;
    public PlayerData data;
    public static Player instance;
    Transform trans;
    Rigidbody2D rigid;
    public Animator anim;
    public Scanner scanner;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        damage = data.damage[playerlevel];
        critical = data.critical[playerlevel];
        cool = data.cool[playerlevel];
        armor = data.armor[playerlevel];
        health = data.health[playerlevel];
        healthRegen = data.healthRegen[playerlevel];
        duration = data.duration[playerlevel];
        speed = data.speed[playerlevel];
        skill1cool = data.skill1cool[playerlevel];
        skill1length = data.skill1length[playerlevel];
    }

    void Move()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec); // ���ο� ��ġ�� �̵�
        anim.SetBool("1_Move", inputVec != Vector2.zero);

        // ù ��° �ڽ��� RectTransform Scale.x�� ����
        if (transform.childCount > 0) // �ڽ��� �ִ��� Ȯ��
        {
            Transform firstChild = transform.GetChild(0); // ù ��° �ڽ� Transform ��������
            RectTransform rectTransform = firstChild.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                Vector3 scale = rectTransform.localScale;
                if (inputVec.x < 0)
                {
                    scale.x = 1; // �������� �̵� �� ����
                }
                else if (inputVec.x > 0)
                {
                    scale.x = -1; // ���������� �̵� �� ������
                }
                rectTransform.localScale = scale;
            }
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
