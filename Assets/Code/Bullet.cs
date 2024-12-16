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
            // ������ �������� �ӵ� ����
            rigid.velocity = dir * data.bulletspeed[GameManager.instance.Gamelevel];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        per--;
        if (per == 0)
        {
            rigid.velocity = Vector2.zero;    // �ӵ� �ʱ�ȭ
            gameObject.SetActive(false);     // �Ѿ� ��Ȱ��ȭ
            Debug.Log("Bullet disabled. Starting ReGen...");

            // ������ ID�� 0�� ��� 2�� �� �����
            if (Weapon.instace.id == 0)
            {
                StartCoroutine(ReGen());
            }
        }
    }

    IEnumerator ReGen()
    {
        Debug.Log("ReGen coroutine started for weapon ID 0.");
        yield return new WaitForSeconds(2); // 2�� ���

        Debug.Log("Reactivating bullet...");
        gameObject.SetActive(true);         // �Ѿ� Ȱ��ȭ

        Debug.Log("Calling Batch to rearrange weapons...");
        Weapon.instace.Batch();             // ���� ��ġ �ٽ� �ʱ�ȭ
    }


}
