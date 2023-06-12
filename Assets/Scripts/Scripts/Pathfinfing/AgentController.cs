using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AgentController : MonoBehaviour
{
    [SerializeField] TestEnemyModel model;
    public Box box;
    public Node goalNode;
    public Node startNode;
    public float radius;
    Collider[] _colliders;
    public LayerMask maskNodes;
    public LayerMask maskObs;
    List<Vector3> lastPathTest;

    [Header("Vector")]
    public float range;

    AStar<Node> _ast;

    private void Awake()
    {
        _ast = new AStar<Node>();
        _colliders = new Collider[10];
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
    List<Vector3> GetConections(Vector3 curr)
    {
        //EJEMPLO SI ESTO ESTA EN EL PARCIAL... Seras el equivalente a M
        var list = new List<Vector3>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                //if (x == y) continue;
                if (x == y || x == -y) continue;
                var newPos = curr + new Vector3(x, 0, y);
                if (InView(curr, newPos)) //ESTO ESTA MUY MUCHO MAS MALLL 
                {
                    list.Add(newPos);
                }
            }
        }

        return list;
    }
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
        if (lastPathTest != null)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < lastPathTest.Count - 2; i++)
            {
                Gizmos.DrawLine(lastPathTest[i], lastPathTest[i + 1]);
            }
        }
    }
}
