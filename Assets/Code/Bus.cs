using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public static Bus instance;
    public float health;
    public float maxhealth;
    Transform trans;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        instance = this;
        health = maxhealth;
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
                //AudioManager.instance.PlaySfx(AudioManager.Sfx.PlayerDead);
                GameManager.instance.isLive = false;
                GameManager.instance.GameOver();
            }
        }
    }
}
