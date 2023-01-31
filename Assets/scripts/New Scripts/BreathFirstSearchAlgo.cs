using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathFirstSearchAlgo : MonoBehaviour
{
    [SerializeField] Vector2Int startingpos;
    [SerializeField] Vector2Int destinationpos;

    public Vector2Int StartingPos { get { return startingpos; } }
    public Vector2Int DestinationPos { get { return destinationpos; } }

    Tile startingTile;
    Tile destinationTile;
    Tile currentTile;
    Vector2Int[] SearhDirection = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    Dictionary<Vector2Int, Tile> reached = new Dictionary<Vector2Int, Tile>();
    Queue<Tile> frontier = new Queue<Tile>();
    Dictionary<Vector2Int, Tile> grid;
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
           
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        startingTile = gridManager.Grid[startingpos];
        destinationTile = gridManager.Grid[destinationpos];

        GetNewPath();
    }

    public List<Tile> GetNewPath()
    {
        return GetNewPath(StartingPos);
    }

    public List<Tile> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetGrid();
        BFS(coordinates);
        return GetPath();
    }
    void ExploreNeighbours()
    {
        List<Tile> neighbours = new List<Tile>();

        // Starting a foreachloop for all direction in SearchDirection Array.
        foreach (Vector2Int direction in SearhDirection)
        {
            //Adding direction to currentnode coordinates and assigning to the neighbourcorrdinate variable

            Vector2Int neighbourCorrdinates = currentTile.coordinates + direction;

            //Checking if the grid contain the neighbour corrdinates if yes then add to the neighbour list
            if (grid.ContainsKey(neighbourCorrdinates))
            {
               neighbours.Add(grid[neighbourCorrdinates]); 
            }
           
        }

        // Starting a foreachloop for all neigbour in neighbours list.

        foreach (Tile neighbour in neighbours)
        {
            // checking if reached dictionary does not containt the corrdinate of the neighbour.

            if (!reached.ContainsKey(neighbour.coordinates) && neighbour.IsWalkable)
            {
                neighbour.connectedto = currentTile;
               
                //Adding that neighbour to the rached dictionary and frontier queue.
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
                
            }
        }
    }

    void BFS(Vector2Int coordinates)
    {
        frontier.Clear();
        reached.Clear();
        bool isRunning = true;


        // Adding strating node to queue and dictionary name reached

        frontier.Enqueue(grid[coordinates]);
        reached.Add(coordinates, grid[coordinates]);

        // Playing loop unit there is no element in queue or the bool is false 
        while(frontier.Count > 0 && isRunning)
        {
            // assigning the first element of the queue to currentTile

            currentTile = frontier.Dequeue();
            currentTile.IsExplore = true;
            
            //Calling explore neighbour function.

            ExploreNeighbours();

            //Checking if we reched to the destination node if yes then we break the loop.

            if (currentTile.coordinates == destinationpos)
            {
                isRunning = false;
            }
        }
    }

    List<Tile> GetPath()
    {
        List<Tile> path = new List<Tile>();
        Tile currentnode = destinationTile;

        if (currentnode != null)
        {
            // adding the destination node to the path list
            path.Add(currentnode);
            currentnode.IsPath = true;

            // running a while till the current node is not connected to null
            while (currentnode.connectedto != null)
            {
                currentnode = currentnode.connectedto;
                path.Add(currentnode);
                currentnode.IsPath = true;
            }

        }

        // reverse the path list and then return it
        path.Reverse();
        return path;
    }

    public bool WillBlockThePath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool PreviousState = grid[coordinates].IsWalkable;
            grid[coordinates].IsWalkable = false;
            List<Tile> NewPath = GetNewPath();
            grid[coordinates].IsWalkable = PreviousState;

            if (NewPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;

    }

   
}
