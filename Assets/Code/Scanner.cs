using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // Ž�� ����(������) ����
    public float scanRange;
    // Ž�� ��� ���̾ �����ϱ� ���� LayerMask
    public LayerMask targetLayer;
    // Ž���� ��� ��� ������ �����ϴ� �迭
    public RaycastHit2D[] targets;
    // Ž���� ��� �� ���� ����� ����� Transform
    public Transform nearestTarget;

    // MonoBehaviour�� FixedUpdate(): ���� ������ �������� ȣ��Ǹ� ���� ���꿡 ����
    void FixedUpdate()
    {
        // ���� Ž���� �����Ͽ� scanRange ���� �ִ� targetLayer�� �ش��ϴ� ��� ��ü�� �˻�
        targets = Physics2D.CircleCastAll(
            transform.position,  // ���� �߽� ��ǥ (���� ��ü ��ġ)
            scanRange,           // Ž�� ���� (������)
            Vector2.zero,        // ���� (0���� �����Ͽ� ��� ���� Ž��)
            0,                   // �Ÿ� (������� ����)
            targetLayer          // Ž�� ��� ���̾�
        );

        // Ž���� ��ü �� ���� ����� ��ü�� ã�Ƽ� nearestTarget�� ����
        nearestTarget = GetNearest();
    }

    // Ž���� ��ü �� ���� ����� ��ü�� ��ȯ�ϴ� �Լ�
    Transform GetNearest()
    {
        Transform result = null; // ���� ����� ��ü�� Transform ����
        float diff = 100;        // �ʱ� �Ÿ� ���̸� ū ������ ����

        // Ž���� ��� ��ü�� �ݺ��Ͽ� ���� ����� ��ü�� ã��
        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;       // ���� ��ü�� ��ġ
            Vector3 targetPos = target.transform.position; // Ž���� ��ü�� ��ġ
            float curDiff = Vector3.Distance(myPos, targetPos); // ���� ��ü�� Ž���� ��ü ���� �Ÿ� ���

            // �Ÿ� ���̰� ���� ����� �ּ� �Ÿ����� ������ ����
            if (curDiff < diff)
            {
                diff = curDiff;        // �ּ� �Ÿ� ����
                result = target.transform; // ���� ����� ��ü�� Transform ����
            }
        }

        // ���� ����� ��ü�� Transform ��ȯ
        return result;
    }
}