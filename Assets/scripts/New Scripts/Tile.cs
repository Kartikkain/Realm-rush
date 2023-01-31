using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile 
{
    public Vector2Int coordinates;
    public bool IsWalkable;
    public bool IsExplore;
    public bool IsPath;
    public Tile connectedto;

    public Tile(Vector2Int coordinates, bool IsWalkable)
    {
        this.coordinates = coordinates;
        this.IsWalkable = IsWalkable;
    }
}
