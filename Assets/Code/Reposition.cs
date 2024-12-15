using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // ��ü�� Collider2D ������Ʈ ����
    Collider2D coll;

    // MonoBehaviour�� Awake(): �ʱ�ȭ �۾� ����
    void Awake()
    {
        // Collider2D ������Ʈ ��������
        coll = GetComponent<Collider2D>();
    }

    // ��ü�� Ư�� Collider�� ����� �� ȣ��
    void OnTriggerExit2D(Collider2D collision)
    {
        // �浹 ����� "Area" �±װ� �ƴϸ� ó�� �ߴ�
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        // �÷��̾�� ���� ��ü�� ��ġ�� ���
        Vector3 playerPos = GameManager.instance.player.transform.position; // �÷��̾� ��ġ
        Vector3 myPos = transform.position; // ���� ��ü ��ġ

        // ��ü �±׿� ���� ���ġ ���� ó��
        switch (transform.tag)
        {
            case "Ground": // �±װ� "Ground"�� ���
                float diffX = playerPos.x - myPos.x; // �÷��̾���� X�� ����
                float diffY = playerPos.y - myPos.y; // �÷��̾���� Y�� ����
                float dirX = diffX < 0 ? -1 : 1; // X�� �̵� ����
                float dirY = diffY < 0 ? -1 : 1; // Y�� �̵� ����

                // ���밪���� �Ÿ� ���
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                // X�� ���̰� ũ�� X�� �������� �̵�
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40); // X�� �̵�
                }
                // Y�� ���̰� ũ�� Y�� �������� �̵�
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40); // Y�� �̵�
                }
                break;

            case "Enemy": // �±װ� "Enemy"�� ���
                // Collider�� Ȱ��ȭ�Ǿ� ���� ���� ����
                if (coll.enabled)
                {
                    Vector3 dist = playerPos - myPos; // �÷��̾���� �Ÿ� ����
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0); // ���� ������
                    transform.Translate(ran + dist * 2); // �Ÿ��� ���� ���� ������� �̵�
                }
                break;
        }
    }
}
