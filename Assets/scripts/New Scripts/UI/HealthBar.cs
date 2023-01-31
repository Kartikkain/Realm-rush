using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    float barlenght;
    float barlenghtSmoother;
    [SerializeField] float barlenghtsmoothervalue;
    [SerializeField] HealthData healthData;


    private void Update()
    {
        UpdateHealthBar(healthData.Health);
    }

     void  UpdateHealthBar( float health)
    {
        barlenght = health;
        barlenghtSmoother += (barlenght - barlenghtSmoother) * Time.deltaTime * barlenghtsmoothervalue;
        transform.localScale = new Vector2(barlenghtSmoother, transform.localScale.y);
    }
}
