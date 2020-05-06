using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinity : MonoBehaviour
{
    public float sp = 0.001f;
    private Vector2 vector;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float go=GetComponent<Renderer>().material.GetTextureOffset("_MainTex").x;
            vector.x = go - sp;
            vector.y = 0;
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", vector);
    }
}
