using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // 객체의 Collider2D 컴포넌트 참조
    Collider2D coll;

    // MonoBehaviour의 Awake(): 초기화 작업 수행
    void Awake()
    {
        // Collider2D 컴포넌트 가져오기
        coll = GetComponent<Collider2D>();
    }

    // 객체가 특정 Collider를 벗어났을 때 호출
    void OnTriggerExit2D(Collider2D collision)
    {
        // 충돌 대상이 "Area" 태그가 아니면 처리 중단
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        // 플레이어와 현재 객체의 위치를 계산
        Vector3 playerPos = GameManager.instance.player.transform.position; // 플레이어 위치
        Vector3 myPos = transform.position; // 현재 객체 위치

        // 객체 태그에 따라 재배치 동작 처리
        switch (transform.tag)
        {
            case "Ground": // 태그가 "Ground"일 경우
                float diffX = playerPos.x - myPos.x; // 플레이어와의 X축 차이
                float diffY = playerPos.y - myPos.y; // 플레이어와의 Y축 차이
                float dirX = diffX < 0 ? -1 : 1; // X축 이동 방향
                float dirY = diffY < 0 ? -1 : 1; // Y축 이동 방향

                // 절대값으로 거리 계산
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                // X축 차이가 크면 X축 방향으로 이동
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40); // X축 이동
                }
                // Y축 차이가 크면 Y축 방향으로 이동
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40); // Y축 이동
                }
                break;

            case "Enemy": // 태그가 "Enemy"일 경우
                // Collider가 활성화되어 있을 때만 동작
                if (coll.enabled)
                {
                    Vector3 dist = playerPos - myPos; // 플레이어와의 거리 벡터
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0); // 랜덤 오프셋
                    transform.Translate(ran + dist * 2); // 거리와 랜덤 값을 기반으로 이동
                }
                break;
        }
    }
}
