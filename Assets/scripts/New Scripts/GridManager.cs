using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int GridSize;
    [SerializeField] int UnitySnapSize = 10;
    Dictionary<Vector2Int, Tile> grid = new Dictionary<Vector2Int, Tile>();
    public Dictionary<Vector2Int, Tile> Grid { get { return grid; } }
    public int unitysnapsize { get { return UnitySnapSize; } }
    // Start is called before the first frame update

    private void Awake()
    {
        GridDesign();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGrid()
    {
        foreach(KeyValuePair<Vector2Int,Tile> entry in grid)
        {
            entry.Value.connectedto = null;
            entry.Value.IsExplore = false;
            entry.Value.IsPath = false;
        }
    }
    public Tile GetTile(Vector2Int currentposition)
    {
        if (grid.ContainsKey(currentposition))
        {
            return grid[currentposition];
        }

        return null;
    }

    public void BlockTile(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].IsWalkable = false;
        }
    } 

    public Vector2Int GetCoordinateFromPosition(Vector3 position)
    {
        Vector2Int coordinate = new Vector2Int();
        coordinate.x = Mathf.RoundToInt(position.x / UnitySnapSize);
        coordinate.y = Mathf.RoundToInt(position.z / UnitySnapSize);

        return coordinate;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * UnitySnapSize;
        position.z = coordinates.y * UnitySnapSize;

        return position;
    }

    void GridDesign()
    {
        for(int x = 0; x < GridSize.x; x++)
        {
            for(int y = 0; y < GridSize.y; y++)
            {
                //adding Tiles in the grid

                Vector2Int currentpos = new Vector2Int(x, y);
                grid.Add(currentpos, new Tile(currentpos, true));
                
            }
        }
       
    }
}
