using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bosscontrol : MonoBehaviour
{
    public Text gameover;
    public Text restart;
    public static bool gamedel2 = false;
    public static bool clear = false;
    // Start is called before the first frame update
    void Start()
    {
        gameover.text = " ";
        restart.text = " ";
    }
    void lose()
    {
        if (gamedel2)
        {
            clear = false;
            gameover.color = Color.cyan;
            gameover.text = "Game Over";
            restart.text = "Click R to restart\n" + "Click Backspace to main\n"+ "Click H to Hardmode\n" + "Click E to Easymode";
            if (Input.GetKey(KeyCode.R))
            {
                gamedel2 = false;
                SceneManager.LoadScene(2);
            }
            if (Input.GetKey(KeyCode.H))
            {
                gamedel2 = false;
                enemy.broken = 50;
                SceneManager.LoadScene(2);
            }
            if (Input.GetKey(KeyCode.E))
            {
                gamedel2 = false;
                enemy.broken = 0;
                SceneManager.LoadScene(2);
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                gamedel2 = false;
                enemy.broken = 0;
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            finish();
        }
    }
    void finish()
    {
        if (clear)
        {
            gameover.color=Color.green;
            gameover.text = "Victory";
            restart.text = "Click Backspace to main";
            Invoke("Backmain", 10f);
            if (Input.GetKey(KeyCode.Backspace))
            {
                enemy.broken = 0;
                clear = true;
                SceneManager.LoadScene(2);
            }
        }
    }
    void Update()
    {
        lose();
    }
    void Backmain()
    {
        if (!gamedel2)
        {
            clear = true;
            enemy.broken = 0;
            SceneManager.LoadScene(2);
        }
    }
}
