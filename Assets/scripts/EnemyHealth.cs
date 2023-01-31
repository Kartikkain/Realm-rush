using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] HealthData healthData;
    [SerializeField] GameObject destroyparticles;
    [SerializeField] float maxHealth=6.0f;
    [SerializeField] [Range(1,4)] int ramhelthup = 1;
    float currentHealth=0f;
    EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHealth = maxHealth;
        healthData.Health = currentHealth / maxHealth;
    }

    private void Awake()
    {
       
    }
    void Start()
    {
        enemyBehaviour = FindObjectOfType<EnemyBehaviour>();   
    }

    // Update is called once per frame
    void Update()
    {
        healthData.Health = currentHealth / maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHealth--;
        healthData.Health = currentHealth / maxHealth;
        if(currentHealth<=0)
        {
            Instantiate(destroyparticles, transform.position, Quaternion.identity);
            enemyBehaviour.Reward();
            gameObject.SetActive(false);
            maxHealth += ramhelthup;
        }
    }
}
