using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AgentController : MonoBehaviour
{
    [SerializeField] GameObject agent;
    [SerializeField] Grid grid;
    [SerializeField] TestEnemyModel model;
    public GameObject box;
    public Node goalNode;
    public Node startNode;
    public float radius;
    Collider[] _colliders;
    public LayerMask maskNodes;
    public LayerMask maskObs;
    [SerializeField] Vector3 detectionArea;
    [SerializeField] LayerMask nodeLayermask;

    Pathfinding pathfinder;

    [Header("Vector")]
    public float range;

    private void Awake()
    {
        _colliders = new Collider[10];
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T)) AStarRun();
        if (Input.GetKeyDown(KeyCode.T)) PathfinderRun();
    }
    void PathfinderRun()
    {
        startNode = grid.GetNodeFromWorldPoint(agent.transform.position);
        goalNode = grid.GetNodeFromWorldPoint(box.transform.position);
        pathfinder = new Pathfinding(grid);
        pathfinder.FindPath(agent.transform.position, box.transform.position);
        model.SetWayPoints(grid.path);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(agent.transform.position, Vector3.one);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(box.transform.position, Vector3.one);

    }

}
