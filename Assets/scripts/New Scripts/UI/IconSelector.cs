using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IconSelector : MonoBehaviour
{
    [SerializeField] Tower tower;
    public delegate void ChangeTower(Tower tower);
    public static event ChangeTower NewTower;


    private void Awake()
    {
        ischildenable(false);
    }
    private void OnMouseUp()
    {

        if (NewTower != null)
        {
            NewTower(tower);
        }

        // if mouse click happens then set childrens enable
        this.ischildenable(true);

        IconSelector[] iconSelector = FindObjectsOfType<IconSelector>();

        // for other iconselector childrens disable

        foreach(IconSelector icon in iconSelector)
        {
            if (icon != this) icon.ischildenable(false);
        }
       
    }

    // setting this game object child's on and off
    private void ischildenable(bool isactive)
    {
        transform.GetChild(0).gameObject.SetActive(isactive);
    }
}
