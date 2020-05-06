using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Randommake : MonoBehaviour
{
    public GameObject jet;
    public Vector2 rdvalue;
    public Text gameover;
    public Text restart;
    private int clear = 0;
    public static bool gamedel = false;
    // Start is called before the first frame update
    void Start()
    {
        gameover.text = " ";
        restart.text = " ";
        InvokeRepeating("Vwave", 0f, 1.5f);
    }

    private void Update()
    {
        Gameover();
    }
    void Gameover()
    {
        if (gamedel)
        {
            gameover.color = Color.cyan;
            gameover.text = "Game Over";
            restart.text = "Click R to restart\n" + "Click Backspace to main";
            if (Input.GetKey(KeyCode.R))
            {
                gamedel = false;
                enemy.broken = 0;
                SceneManager.LoadScene(1);
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                gamedel = false;
                enemy.broken = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
    void Boss()
    {
        if (!gamedel)
            SceneManager.LoadScene(2);
    }
    void showhide()
    {
        if (!gamedel)
        {
        if (gameover.text == " ")
            gameover.text = "Waring!";
        else
            gameover.text = " ";
        }
    }
    void Vwave()
    {
        if (clear < 60)
        {
            Vector2 rdposition = new Vector2(Random.Range(-rdvalue.x, rdvalue.x), rdvalue.y);
            Instantiate(jet, rdposition, Quaternion.identity);
            clear++;
        }
        else
        {
            CancelInvoke("Vwave");
            if (!gamedel)
            {
                gameover.color = Color.red;
                InvokeRepeating("showhide", 0.0f, 0.1f);
                Invoke("Boss", 10f);
            }
        }
    }
}
