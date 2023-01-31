using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0.1f,30f)] float delayTime = 5f;
    [SerializeField] [Range(0,30)]int poolsize = 5;
    GameObject[] pool;
    // Start is called before the first frame update

    void Awake()
    {
        populatepool();  
    }
    void Start()
    {
        StartCoroutine(EnemySpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populatepool()
    {
        pool = new GameObject[poolsize];

        for(int i=0;i<pool.Length;i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
                
    }

    void EnableObjects()
    {
        for(int i=0;i<pool.Length;i++)
        {
            if(pool[i].activeInHierarchy==false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

   IEnumerator EnemySpawning()
    {
        while(true)
        {
            EnableObjects();
            yield return new WaitForSeconds(delayTime);
        }
        
    }
}
