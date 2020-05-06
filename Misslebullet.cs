using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misslebullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public GameObject enemyanim;
    public GameObject playeranim;
    private int hp = 4;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
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
            hp = 5;
        }
        if (collision.gameObject.tag == ("Player"))
        {
            Instantiate(enemyanim, transform.position, transform.rotation);
            Instantiate(playeranim, collision.transform.position, collision.transform.rotation);
            Bosscontrol.gamedel2 = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
