﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybomb : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
