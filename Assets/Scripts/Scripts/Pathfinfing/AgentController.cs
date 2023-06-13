using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AgentController : MonoBehaviour
{
    [SerializeField] TestEnemyModel model;
    public Box box;
    Node goalNode;
    public Node startNode;
    public float radius;
    Collider[] _colliders;
    public LayerMask maskNodes;
    public LayerMask maskObs;
    List<Vector3> lastPathTest;
    [SerializeField] Vector3 detectionArea;
    [SerializeField] LayerMask nodeLayermask;
    List<Vector3> wpList;
    public List<Node> wpNodeList;

    [Header("Vector")]
    public float range;

    AStar<Node> _ast;

    public List<Vector3> WpList { get => wpList; set => wpList = value; }

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
        if (Input.GetKeyDown(KeyCode.T)) AStarRun();
    }

    public void AStarRun()
    {
        Debug.Log("Running AStar Script");
        var start = startNode;
        if (start == null) return;
        Collider[] coll = Physics.OverlapSphere(new Vector3(Random.Range(0, 2), 0, Random.Range(0, 2)), .1f, nodeLayermask);
        if(coll.Length > 0)
        {
            goalNode = coll[0].gameObject.GetComponent<Node>();
            Debug.Log("Node found at: " + goalNode.transform.position);
        }
        else
        {
            Debug.Log("Node not found");
            return;
        }
        var path = _ast.Run(start, Satisfies, GetConections, GetCost, Heuristic, 500);
        model.SetWayPoints(path);
        box.SetWayPoints(path);
    }
    public void AStarPlusRun()
    {
        var start = startNode;
        if (start == null) return;
        var path = _ast.Run(start, Satisfies, GetConections, GetCost, Heuristic, 500);
        path = _ast.CleanPath(path, InView);
        model.SetWayPoints(path);
        box.SetWayPoints(path);
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
        if (Physics.Linecast(from.transform.position, to.transform.position, maskObs)) return false;
        //Distance
        //Angle
        return true;
    }
    float Heuristic(Node curr)
    {
        float multiplierDistance = 2;
        float cost = 0;
        cost += Vector3.Distance(curr.transform.position, goalNode.transform.position) * multiplierDistance;
        return cost;
    }
    float GetCost(Node parent, Node son)
    {
        float multiplierDistance = 1;
        //float multiplierEnemies = 20;
        float multiplierTrap = 20;

        float cost = 0;
        cost += Vector3.Distance(parent.transform.position, son.transform.position) * multiplierDistance;
        if (son.hasTrap)
            cost += multiplierTrap;
        //cost += 100 * multiplierEnemies;
        return cost;
    }
    List<Node> GetConections(Node curr)
    {
        return curr.neightbourds;
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
