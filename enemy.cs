using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject bombPrefab;
    public static int broken ;
    private float sp = 1.5f;
    private int hp = 2;
    private float BulletInterval;
    private float time = 0;
    public GameObject enemyanim;
    public GameObject playeranim;
    AudioSource sound;
    Shipmove player;

    private void Start()
    {
        BulletInterval = 1.3f;
        sound = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        Move();
        shoot();
    }
    void Move()
    {
        Vector2 temp = transform.position;
        temp.x += Random.Range(-0.3f, 0.3f);
        temp.y -= sp * Time.deltaTime;
        transform.position = temp;

    }
    void shoot()
    {
        time += Time.deltaTime;
        if (time > BulletInterval)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.Euler(0, 0, 180));
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("laser"))
        {
            hp--;
            Destroy(collision.gameObject);
            sound.Play();
        }
        if (hp == 0)
        {
            Instantiate(enemyanim, transform.position, transform.rotation);
            Destroy(this.gameObject);
            hp = 6;
            broken++;
        }
        if (collision.gameObject.tag == ("Player"))
        {
            Instantiate(enemyanim, transform.position, transform.rotation);
            Instantiate(playeranim, collision.transform.position, collision.transform.rotation);
            Randommake.gamedel = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
