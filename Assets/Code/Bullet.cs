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
            // 지정된 방향으로 속도 설정
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
            Debug.Log("Bullet disabled. Starting ReGen...");

            // 무기의 ID가 0인 경우 2초 뒤 재생성
            if (Weapon.instace.id == 0)
            {
                StartCoroutine(ReGen());
            }
        }
    }

    IEnumerator ReGen()
    {
        Debug.Log("ReGen coroutine started for weapon ID 0.");
        yield return new WaitForSeconds(2); // 2초 대기

        Debug.Log("Reactivating bullet...");
        gameObject.SetActive(true);         // 총알 활성화

        Debug.Log("Calling Batch to rearrange weapons...");
        Weapon.instace.Batch();             // 무기 배치 다시 초기화
    }


}
