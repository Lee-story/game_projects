using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmove : MonoBehaviour
{
    public Transform[] BossPos;
    private float alpha = 0f;
    public float sp = 0.1f;
    private int hp = 200;
    private float time = 0;
    private float BulletInterval;
    public static bool choosemode = false;
    public GameObject bombPrefab;
    public GameObject misslePrefab;
    public GameObject Bossanim;
    AudioSource sound;

    private void Start()
    {
        if (choosemode)
         {
            hp = 400;
            BulletInterval = 0.7f;
            InvokeRepeating("missle", 5f, 0.8f);
        }
         else
         {
            BulletInterval = 1;
            InvokeRepeating("missle", 5f, 3f);
         }
        sound = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        shoot();
    }
    void missle()
    {
        Instantiate(misslePrefab, BossPos[0].position, Quaternion.Euler(0, 0, 180));
        Instantiate(misslePrefab, BossPos[1].position, Quaternion.Euler(0, 0, 180));
    }
    void Move()
    {
        transform.position = new Vector2(Mathf.PingPong(alpha, 12.6f), transform.position.y);
        alpha += sp;
    }
    void shoot()
    {
        time += Time.deltaTime;
        if (time > BulletInterval)
        {
            Instantiate(bombPrefab, BossPos[2].position, Quaternion.Euler(0,0,-25));
            Instantiate(bombPrefab, BossPos[4].position, Quaternion.identity);
            Instantiate(bombPrefab, BossPos[3].position, Quaternion.Euler(0, 0, 25));
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
            Bosscontrol.clear = true;
            Instantiate(Bossanim, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
