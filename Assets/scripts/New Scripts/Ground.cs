using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ground : MonoBehaviour
{
    [SerializeField] Tower towerprefab;
    [SerializeField] bool isplaced;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    BreathFirstSearchAlgo SearchAlgo;
    public delegate void ChangePath(bool reset);
    public static event ChangePath CalculatePath;

    private void OnEnable()
    {
        IconSelector.NewTower += AssignplayerchoosenTower;
    }
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        SearchAlgo = FindObjectOfType<BreathFirstSearchAlgo>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinateFromPosition(transform.position);
            if (!isplaced)
            {
                gridManager.BlockTile(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (towerprefab != null)
        {

            if (gridManager.GetTile(coordinates).IsWalkable && !SearchAlgo.WillBlockThePath(coordinates))
            {
                bool placed = towerprefab.CreateTower(towerprefab, transform.position);
                if (placed)
                {
                    gridManager.BlockTile(coordinates);
                    if (CalculatePath != null)
                    {
                        CalculatePath(false);
                    }
                }
            }
        }
    }

    void AssignplayerchoosenTower( Tower tower)
    {
        towerprefab = tower;
    }

    private void OnDisable()
    {
        IconSelector.NewTower -= AssignplayerchoosenTower;
    }
}
