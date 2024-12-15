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
        // 원형 탐지를 수행하여 scanRange 내에 있는 targetLayer에 해당하는 모든 객체를 검색
        targets = Physics2D.CircleCastAll(
            transform.position,  // 원의 중심 좌표 (현재 객체 위치)
            scanRange,           // 탐지 범위 (반지름)
            Vector2.zero,        // 방향 (0으로 설정하여 모든 방향 탐지)
            0,                   // 거리 (사용하지 않음)
            targetLayer          // 탐지 대상 레이어
        );

        // 탐지된 객체 중 가장 가까운 객체를 찾아서 nearestTarget에 저장
        nearestTarget = GetNearest();
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
