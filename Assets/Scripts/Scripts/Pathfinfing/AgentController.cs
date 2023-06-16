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
    //List<Vector3> wpList;
    //public List<Node> wpNodeList;

    [Header("Vector")]
    public float range;

    AStar<Node> _ast;

    //public List<Vector3> WpList { get => wpList; set => wpList = value; }

    private void Awake()
    {
        _ast = new AStar<Node>();
        _colliders = new Collider[10];
    }
    private void Start()
    {

    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T)) AStarRun();
        if (Input.GetKeyDown(KeyCode.T)) PathfinderRun();
    }

    void PathfinderRun()
    {
        startNode = SetConditionalNode(agent.transform.position).GetComponent<Node>();
        var start = startNode;
        if (start == null)
        {
            Debug.Log("StartNode is null");
            return;
        }

        var node = SetConditionalNode(box.transform.position);
        if (node != null) goalNode = node.GetComponent<Node>();
        if (goalNode == null)
        {
            Debug.Log("GoalNode is null");
            return;
        }

        //else return;
        //else
        //{
        //    Debug.Log("Node not found");
        //    return;

        //}
        if (startNode != null && goalNode != null)
        {
            Debug.Log("Start and end node succesfully set!" + startNode.worldPosition + goalNode.worldPosition);
            pathfinder = new Pathfinding(goalNode.transform, grid);
            pathfinder.FindPath(startNode.transform.position, goalNode.transform.position);
            Debug.Log("Path set up" + pathfinder.finalPath.Count);
            model.SetWayPoints(pathfinder.finalPath);
            box.GetComponent<Box>().SetWayPoints(pathfinder.finalPath);
        }
    }
    public void AStarRun()
    {
        Debug.Log("Running AStar Script");

        startNode = SetConditionalNode(agent.transform.position).GetComponent<Node>();
        var start = startNode;
        if (start == null)
        {
            Debug.Log("StartNode is null");
            return;
        }

        var node = SetConditionalNode(box.transform.position);
        if (node != null) goalNode = node.GetComponent<Node>();
        if (goalNode == null)
        {
            Debug.Log("GoalNode is null");
            return;
        }

        //else return;
        //else
        //{
        //    Debug.Log("Node not found");
        //    return;

        //}
        if (startNode != null && goalNode != null)
        {
            Debug.Log("Start and end node succesfully set!" + startNode.worldPosition + goalNode.worldPosition);
            var path = _ast.Run(start, Satisfies, GetConections, GetCost, Heuristic, 500);
            Debug.Log("Path set up" + path.Count);
            model.SetWayPoints(path);
            box.GetComponent<Box>().SetWayPoints(path);
        }
    }

    GameObject SetConditionalNode(Vector3 pos)
    {
        GameObject node = null;
        Collider[] coll = Physics.OverlapSphere(pos, 1f, nodeLayermask);
        if (coll.Length > 0) return node = coll[0].gameObject;
        else return null;
    }

    public void AStarPlusRun()
    {
        var start = startNode;
        if (start == null) return;
        var path = _ast.Run(start, Satisfies, GetConections, GetCost, Heuristic, 500);
        path = _ast.CleanPath(path, InView);
        model.SetWayPoints(path);
        box.GetComponent<Box>().SetWayPoints(path);
    }

    bool Satisfies(Vector3 curr)
    {
        var distance = Vector3.Distance(curr, box.transform.position);
        if (distance > range) return false;
        if (Physics.Linecast(curr, box.transform.position, maskObs)) return false;
        return true;
    }
    //List<Vector3> GetConections(Vector3 curr)
    //{
    //    wpList = new List<Vector3>();
    //    wpNodeList = new List<GameObject>();
    //    Collider[] coll = Physics.OverlapBox(model.transform.position, detectionArea, Quaternion.identity, nodeLayermask);
    //    foreach (var c in coll)
    //    {
    //        wpList.Add(c.gameObject.transform.position);
    //        wpNodeList.Add(c.gameObject);
    //    }
    //    Debug.Log("List of connections: " + wpList);
    //    return wpList;
    //}
    bool InView(Vector3 from, Vector3 to)
    {
        Debug.Log("CLEAN");
        if (Physics.Linecast(from, to, maskObs)) return false;
        //Distance
        //Angle
        return true;
    }

    float GetCost(Vector3 parent, Vector3 son)
    {
        float multiplierDistance = 1;
        float cost = 0;
        cost += Vector3.Distance(parent, son) * multiplierDistance;
        return cost;
    }

    float Heuristic(Vector3 curr)
    {
        float multiplierDistance = 2;
        float cost = 0;
        cost += Vector3.Distance(curr, box.transform.position) * multiplierDistance;
        return cost;
    }

    bool InView(Node from, Node to)
    {
        Debug.Log("CLEAN");
        if (Physics.Linecast(from.worldPosition, to.worldPosition, maskObs)) return false;
        //Distance
        //Angle
        return true;
    }
    float Heuristic(Node curr)
    {
        float multiplierDistance = 2;
        float cost = 0;
        cost += Vector3.Distance(curr.worldPosition, goalNode.worldPosition) * multiplierDistance;
        return cost;
    }
    float GetCost(Node parent, Node son)
    {
        son = goalNode;
        float multiplierDistance = 1;
        //float multiplierEnemies = 20;
        float multiplierTrap = 20;

        float cost = 0;
        cost += Vector3.Distance(parent.worldPosition, son.worldPosition) * multiplierDistance;
        //if (son.hasTrap)
        cost += multiplierTrap;
        //cost += 100 * multiplierEnemies;
        return cost;
    }
    List<Node> GetConections(Node curr)
    {
        return curr.Neighbors;
    }
    bool Satisfies(Node curr)
    {
        return curr == goalNode;
    }
    Node GetStartNode()
    {
        int count = Physics.OverlapSphereNonAlloc(model.transform.position, radius, _colliders, maskNodes);
        float bestDistance = 0;
        Collider bestCollider = null;
        for (int i = 0; i < count; i++)
        {
            Collider currColl = _colliders[i];
            float currDistance = Vector3.Distance(model.transform.position, currColl.transform.position);
            if (bestCollider == null || bestDistance > currDistance)
            {
                bestDistance = currDistance;
                bestCollider = currColl;
            }
        }
        if (bestCollider != null)
        {
            return bestCollider.GetComponent<Node>();
        }
        else
        {
            return null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(model.transform.position, detectionArea);
    }

}
