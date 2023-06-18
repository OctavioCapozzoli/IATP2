using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Pathfinding
{
    public Transform seeker, target;
    Grid grid;
    public List<Node> finalPath;
    Vector3 lastPos;

    public Pathfinding(/*Transform _target,*/ Grid _grid)
    {
        //seeker = _seeker;
        //target = _target;
        //lastPos = _lastPos;
        grid = _grid;
    }
    public void FindPath(Vector3 _startPosition, Vector3 _targetPosition)//, Func<Vector3,bool> isSatisfies)
    {
        Node startNode = grid.GetNodeFromWorldPoint(_startPosition);
        Node targetNode = grid.GetNodeFromWorldPoint(_targetPosition);

        Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.isWalkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.ContainsItem(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.ContainsItem(neighbour))
                        openSet.Add(neighbour);
                    else
                    {
                        //openSet.UpdateItem(neighbour);
                    }
                }
            }
        }


    }

    List<Node> RetracePath(Node _startNode, Node _endNode)
    {
        List<Node> path = new List<Node>();

        Node currentNode = _endNode;

        while (currentNode != _startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        grid.path = path;
        return path;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distX > distY) return (14 * distY) + (10 * (distX - distY));
        return (14 * distX) + (10 * (distY - distX));
    }
}
