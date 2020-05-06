using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class side
{
    public float xmax, xmin, ymax, ymin;
}
public class Shipmove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] ShipPos;
    public GameObject bombPrefab;
    public Rigidbody2D rb;
    public GameObject playeranim;
    private float BulletInterval;
    private float time = 0;
    public float sp = 0.1f;
    public side sd;
    AudioSource lazer;

    void Start()
    {
        BulletInterval = 0.1f;
    }
    void Update()
    {
        move();
        shoot();
    }
    void shoot()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && time > BulletInterval)
        {
            Instantiate(bombPrefab, ShipPos[0].position, Quaternion.identity);
           if (enemy.broken > 9&& enemy.broken < 30)
            {
                Instantiate(bombPrefab, ShipPos[1].position, Quaternion.identity);
            }
            if (enemy.broken > 29)
            {
                Instantiate(bombPrefab, ShipPos[1].position, Quaternion.Euler(0, 0, 10));
                Instantiate(bombPrefab, ShipPos[2].position, Quaternion.Euler(0,0,-10));
            }
            time = 0;
            lazer = this.GetComponent<AudioSource>();
            lazer.Play();
        }
    }
    void move()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveH, moveV);
        rb.velocity = movement * sp;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, sd.xmin, sd.xmax), Mathf.Clamp(rb.position.y, sd.ymin, sd.ymax));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            Randommake.gamedel = true;
            Instantiate(playeranim, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == ("Boss"))
        {
            Bosscontrol.gamedel2 = true;
            Instantiate(playeranim, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == ("Bossbullet"))
        {
            Bosscontrol.gamedel2 = true;
            Instantiate(playeranim, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
