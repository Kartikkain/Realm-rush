using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoorSystem : MonoBehaviour
{
    [SerializeField] Color defaultcolor = Color.white;
    [SerializeField] Color ExpoloreTilecolor = Color.yellow;
    [SerializeField] Color pathTilecolor = Color.red;
    [SerializeField] Color blockedTileColor = Color.gray;
    
    TextMeshPro label;
    Vector2Int coordinate;
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        CoordinateForTile();
        updateNameOfTile();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {

            CoordinateForTile();
            updateNameOfTile();
            label.enabled = true;
        }
        SetLabelColor();
        Togglecoordinates();
    }
    void CoordinateForTile()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.unitysnapsize);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.unitysnapsize);

        label.text = coordinate.x + "," + coordinate.y;
    }

    void SetLabelColor()
    {
        if(gridManager == null) { return; }

        Tile tile = gridManager.GetTile(coordinate);

        if(tile == null) { return; }

        if (!tile.IsWalkable)
        {
            label.color = blockedTileColor;
        }
        else if (tile.IsPath)
        {
            label.color = pathTilecolor;
        }
        else if (tile.IsExplore)
        {
            label.color = ExpoloreTilecolor;
        }
        else
        {
            label.color = defaultcolor;
        }
    }
    void updateNameOfTile()
    {
        transform.parent.name = coordinate.ToString();
    }
 
    void Togglecoordinates()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
