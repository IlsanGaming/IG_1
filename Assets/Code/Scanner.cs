using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // 탐지 범위(반지름) 설정
    public float scanRange;
    // 탐지 대상 레이어를 설정하기 위한 LayerMask
    public LayerMask targetLayer;
    // 탐지된 모든 대상 정보를 저장하는 배열
    public RaycastHit2D[] targets;
    // 탐지된 대상 중 가장 가까운 대상의 Transform
    public Transform nearestTarget;

    // MonoBehaviour의 FixedUpdate(): 고정 프레임 간격으로 호출되며 물리 연산에 적합
    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(
            transform.position,
            scanRange,
            Vector2.zero,
            0,
            targetLayer
        );

        nearestTarget = GetNearest();

        if (targets.Length == 0)
        {
            Debug.LogWarning("No targets found within scan range.");
        }
        else if (nearestTarget == null)
        {
            Debug.LogWarning("No nearest target found, but targets exist.");
        }
        else
        {
            Debug.Log($"Nearest target found at: {nearestTarget.position}");
        }
    }


    // 탐지된 객체 중 가장 가까운 객체를 반환하는 함수
    Transform GetNearest()
    {
        Transform result = null; // 가장 가까운 객체의 Transform 저장
        float diff = 100;        // 초기 거리 차이를 큰 값으로 설정

        // 탐지된 모든 객체를 반복하여 가장 가까운 객체를 찾음
        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;       // 현재 객체의 위치
            Vector3 targetPos = target.transform.position; // 탐지된 객체의 위치
            float curDiff = Vector3.Distance(myPos, targetPos); // 현재 객체와 탐지된 객체 간의 거리 계산

            // 거리 차이가 현재 저장된 최소 거리보다 작으면 갱신
            if (curDiff < diff)
            {
                diff = curDiff;        // 최소 거리 갱신
                result = target.transform; // 가장 가까운 객체의 Transform 저장
            }
        }

        // 가장 가까운 객체의 Transform 반환
        return result;
    }
}
