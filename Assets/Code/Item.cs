using UnityEngine;

public class Item : MonoBehaviour
{
    public PoolManager.PoolType itemType; // 아이템의 타입을 인스펙터에서 설정

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                gameObject.SetActive(false); // 아이템 비활성화
            }
        }
    }
}
