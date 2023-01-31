using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int maxCoins = 150;
    [SerializeField] int currentCoins;
    [SerializeField] TextMeshProUGUI coin;

    public int CurrentCoin { get{ return currentCoins; } }
    // Start is called before the first frame update
    void Start()
    {
        
        currentCoins = maxCoins;
        updateCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deposite(int amount)
    {
        currentCoins +=Mathf.Abs(amount);
        updateCoin();
    }

    public void StealCoins(int amount)
    {
        currentCoins -= Mathf.Abs(amount);
        updateCoin();

        if(currentCoins<0)
        {
            int currentindex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentindex);
        }
                
    }
    void updateCoin()
    {
        coin.text = currentCoins.ToString();
    }

        
}
