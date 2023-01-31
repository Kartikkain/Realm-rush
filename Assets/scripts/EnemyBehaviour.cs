using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int GoldReward = 25;
    [SerializeField] int GoldPenalty = 25;
    [SerializeField] float EnemyHitPoints = 25;
    Bank bank;
    Castel castel;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
        castel = FindObjectOfType<Castel>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void DamageCastel()
    {
        if(castel == null) { return; }
        castel.ReduceHealth(EnemyHitPoints);
    }
    public void Reward()
    {
        if (bank == null) { return; }
        bank.Deposite(GoldReward);
    }

    public void Steal()
    {
        if (bank == null) { return; }
        bank.StealCoins(GoldPenalty);
    }
}
