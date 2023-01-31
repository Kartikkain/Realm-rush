using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Castel : MonoBehaviour
{
    [SerializeField] HealthData healthdata;
    [SerializeField] float Castelhealth = 50f;
    float currentHealth;
    public static event Action LooseCanvasActive;

    private void Awake()
    { 
        currentHealth = Castelhealth;
    }

    private void Update()
    {
        healthdata.Health = currentHealth / Castelhealth;
    }

    public void ReduceHealth(float enemyhitpoint)
    {
        currentHealth -= enemyhitpoint;
        if (currentHealth <= 0f && LooseCanvasActive != null)
        {
            LooseCanvasActive();
        }
    }
}
