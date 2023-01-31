using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField] GameObject loosecanvas;

    private void OnEnable()
    {
        GameTimer.OnCanvasActive += EnableCanvas;
        Castel.LooseCanvasActive += EnableCanvas;
    }
    
    void EnableCanvas()
    {
        Time.timeScale = 0;
        loosecanvas.SetActive(true);
    }

    private void OnDisable()
    {
        GameTimer.OnCanvasActive -= EnableCanvas;
        Castel.LooseCanvasActive -= EnableCanvas;
    }
}
