using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] [Range(0.2f,1.5f)]float BuildTime = 0.5f;

    private void Start()
    {
        StartCoroutine(Build());
    }
    public bool CreateTower(Tower tower,Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false; }
        if(bank.CurrentCoin>=cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.StealCoins(cost);
            return true;
        }
                
        
        return false;
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform gradchild in child)
            {
                gradchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(BuildTime);
            foreach (Transform gradchild in child)
            {
                gradchild.gameObject.SetActive(true);
            }
        }
    }
}
