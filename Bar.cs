using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public Text mode;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        mode.text = "";
        choose();
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void choose()
    {
        if (enemy.broken > 39&& !Bosscontrol.clear)
        {
            mode.color = Color.red;
            mode.text = "Hard mode";
            Bossmove.choosemode = true;
        }
        else if(enemy.broken <40 && !Bosscontrol.clear)
        {
            mode.color = Color.green;
            mode.text = "Easy mode";
        }
        else if (Bosscontrol.clear)
        {
            mode.color = Color.white;
            mode.text = "Back menu";
        }
    }
    public void AnimateBar()
    {
     
    }
    private void change()
    {
        if(Bosscontrol.clear)
        {
            Bosscontrol.clear = false;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

}
