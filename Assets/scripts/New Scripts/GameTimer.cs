using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameTimer : MonoBehaviour
{
    [SerializeField] [Range(1,3)] int gametime = 1;
    int starttime;
    TextMeshProUGUI TimeLabel;
    public static event Action OnCanvasActive;
    private void Awake()
    {
        TimeLabel = GetComponent<TextMeshProUGUI>();
        starttime = gametime * 60;
    }
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(Timer(starttime)); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Timer(int timevalue)
    {
        while(timevalue >= 0)
        {
            int minutes = Mathf.RoundToInt(timevalue / 60);
            float seconds = timevalue % 60;
            string timestring = (seconds < 10) ? $"0{minutes} : 0{seconds}" : $"0{minutes} : {seconds}";
            TimeLabel.text = timestring;
            yield return new WaitForSeconds(1f);
            timevalue--;
            if (timevalue == 0)
            {
                if (OnCanvasActive != null)
                {
                    OnCanvasActive();
                }
            }
        }
    }
}
