using UnityEngine;

public class Item : MonoBehaviour
{
    public PoolManager.PoolType itemType; // �������� Ÿ���� �ν����Ϳ��� ����

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                gameObject.SetActive(false); // ������ ��Ȱ��ȭ
            }
        }
    }
}
