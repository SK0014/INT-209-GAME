﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour
{
   public GameObject container;
    public float rotationSpeed=180f;
    public int health=50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        container.transform.Rotate(Vector3.up*rotationSpeed*Time.deltaTime);        
    }
}
