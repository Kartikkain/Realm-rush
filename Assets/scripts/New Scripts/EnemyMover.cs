using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0.5f,5f)]float speed = 2f;
    List<Tile> path = new List<Tile>();
    BreathFirstSearchAlgo pathfinder;
    GridManager gridManager;
    EnemyBehaviour enemyBehaviour;

    private void OnEnable()
    {
        Ground.CalculatePath += FindPath;
        StartFromStartPosition();
        FindPath(true);
    }

    private void Awake()
    {
        pathfinder = FindObjectOfType<BreathFirstSearchAlgo>();
        gridManager = FindObjectOfType<GridManager>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FindPath(bool resetpath)
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetpath)
        {
            coordinates = pathfinder.StartingPos;
        }
        else
        {
            coordinates = gridManager.GetCoordinateFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowThePath());


    }
    void StartFromStartPosition()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartingPos);
    }

    IEnumerator FollowThePath()
    {
        for(int i = 1; i < path.Count; i++)
        {
            Vector3 startingposition = transform.position;
            Vector3 endposition = gridManager.GetPositionFromCoordinates(path[i].coordinates);

            float time = 0f;
            transform.LookAt(endposition);
            while (time < 1f)
            {
                time += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startingposition, endposition,time);
                yield return new WaitForEndOfFrame();
            }

        }
        enemyBehaviour.DamageCastel();
        enemyBehaviour.Steal();
        gameObject.SetActive(false);
    }

    
    private void OnDisable()
    {
        Ground.CalculatePath -= FindPath;
    }
}
