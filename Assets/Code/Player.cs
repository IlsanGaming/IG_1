using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using static Cinemachine.DocumentationSortingAttribute;
using static PoolManager;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    [Header("# Player Object(Do not Touch!)")]
    public float slow;
    public float health=10;
    public float maxhealth;
    public float speed;
    public float speedRegen;
    public float maxspeed;
    public float skill1cool;
    public float maxskill1cool;

    public int playerlevel;
    public int maxplayerlevel;

    public Vector2 inputVec;
    public PlayerData data;
    public WeaponData weaponData;

    public static Player instance;
    Transform trans;
    Rigidbody2D rigid;
    public Animator anim;
    public Scanner scanner;
    public GameObject[] playrSprite;

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
        if (!GameManager.instance.isLive)
        {
            return;
        }
        Move();
        Fire();
        Reload();
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        GetStat();
    }

    public void GetStat()
    {
        slow = data.damage[playerlevel];
        maxhealth = data.health[playerlevel];
        speed = data.speed[playerlevel];
        maxskill1cool = data.skill1cool[playerlevel];
    }

    void Move()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec); // 새로운 위치로 이동
        anim.SetBool("1_Move", inputVec != Vector2.zero);

        // 첫 번째 자식의 RectTransform Scale.x를 변경
        if (transform.childCount > 0) // 자식이 있는지 확인
        {
            Transform firstChild = transform.GetChild(0); // 첫 번째 자식 Transform 가져오기
            RectTransform rectTransform = firstChild.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                Vector3 scale = rectTransform.localScale;
                if (inputVec.x < 0)
                {
                    scale.x = 1; // 왼쪽으로 이동 시 반전
                }
                else if (inputVec.x > 0)
                {
                    scale.x = -1; // 오른쪽으로 이동 시 정방향
                }
                rectTransform.localScale = scale;
            }
        }
    }
    void Fire()
    {
        if (skill1cool < maxskill1cool)
        {
            return;
        }
        if (scanner.nearestTarget == null)
        {
            return;
        }
        int level = playerlevel;
        switch (level)
        {
            case 0:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero, new Color(1, 1, 1));
                break;
            case 1:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.right * 0.1f, new Color(1, 1, 1));
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.left * 0.1f, new Color(1, 1, 1));
                break;
            case 2:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.right * 0.1f, new Color(1, 1, 1));
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.right * 0.2f, new Color(1, 1, 1));
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.left * 0.1f, new Color(1, 1, 1));
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.left * 0.2f, new Color(1, 1, 1));
                break;
            case 3:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero, new Color(1, 1, 1));
                break;
            case 4:
                Createbullet(PoolManager.PoolType.Bullet1, Vector3.zero, new Color(1, 1, 1));
                break;
        }
        // 애니메이션 트리거 설정
        anim.SetTrigger("2_Attack");

        // Cooldown 초기화
        skill1cool = 0;
        StartCoroutine(ResetAttackTrigger());
    }
    IEnumerator ResetAttackTrigger()
    {
        yield return null;
        anim.ResetTrigger("2_Attack");
    }
    void Reload()
    {
        skill1cool += Time.deltaTime;
    }
    void Createbullet(PoolType type, Vector3 offset, Color bulletColor)
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        if (scanner.nearestTarget == null)
        {
            Debug.LogWarning("No target found for Createbullet");
            return; // 타겟이 없으면 총알을 발사하지 않음
        }

        Vector3 targetPos = scanner.nearestTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        if (GameManager.instance.pool == null)
        {
            Debug.LogError("PoolManager is not initialized");
            return;
        }

        Transform bullet = GameManager.instance.pool.Get(PoolManager.PoolType.Bullet1).transform;
        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
        spriteRenderer.color = bulletColor;
        bullet.position = transform.position + offset;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(0, 0, dir);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Shoot);
    }
    public void HandleItemPickup(PoolManager.PoolType type)
    {
        switch (type)
        {
            case PoolManager.PoolType.part:
                GameManager.instance.exp++;
                Debug.Log("Part Collected, Experience Gained");
                break;
            default:
                Debug.LogWarning("Unhandled item type: " + type);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            //OnDamaged(collision.transform.position);
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            // 충돌한 객체에서 Item 컴포넌트를 가져옴
            Item item = collision.gameObject.GetComponent<Item>();
            if (item != null)
            {
                GameManager.instance.GetExp();
                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Collision with item failed to get Item component.");
            }
            AudioManager.instance.PlaySfx(AudioManager.Sfx.PickUp);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health -= Time.deltaTime;
            AudioManager.instance.PlaySfx(AudioManager.Sfx.PlayerHit);
            if (health < 0)
            {
                anim.SetTrigger("4_Death");
                Invoke("Dead", 1f);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.PlayerDead);
            }
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
        GameManager.instance.isLive = false;

    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}