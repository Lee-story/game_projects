using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float baseWidth = 1280;
    public float baseHeight = 1024;
    public new Camera camera;

    void Awake()
    {
        camera.aspect = this.baseWidth / this.baseHeight;
    }
    // Start is called before the first frame update
    bool check;
    public GUIStyle mystyle;
    public GUIStyle mystyle2;
    public GUIStyle mystyle3;

    private void OnGUI()
    {
        GUI.Label(new Rect(550, 312, 200, 200), "Space shooter",mystyle);
        if (GUI.Button(new Rect(440, 512, 100, 100),"",mystyle2))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(740, 512, 100, 100), "", mystyle3))
        {
            Application.Quit();
        }
    }
}
