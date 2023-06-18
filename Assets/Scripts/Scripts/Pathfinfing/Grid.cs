using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform player;
    public LayerMask unwalkableNodeLayerMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public GameObject nodePrefab;
    Node[,] grid;
    //public TerrainType[] walkableRegions;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - (Vector3.right * gridWorldSize.x / 2) - (Vector3.forward * gridWorldSize.y / 2);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + (Vector3.right * ((x * nodeDiameter) + nodeRadius)) + (Vector3.forward * ((y * nodeDiameter) + nodeRadius));
                bool walkable = !Physics.CheckSphere(worldPoint, nodeRadius, unwalkableNodeLayerMask);
                //var go = Instantiate(nodePrefab, worldPoint, Quaternion.identity);
                //Node node = go.GetComponent<Node>(); node.InitNode(walkable, worldPoint, x, y);
                grid[x, y] = new Node(true, worldPoint, x, y);
                Debug.Log("node position data: " + worldPoint + x + y);
            }
        }
    }


    public List<Node> GetNeighbours(Node _currentNode)
    {
        List<Node> neighbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int checkX = _currentNode.gridX + x;
                int checkY = _currentNode.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    if (grid[checkX, checkY] != null) neighbours.Add(grid[checkX, checkY]);
                }
            }
        }
        _currentNode.Neighbors = neighbours;
        return neighbours;
    }

    public Node GetNodeFromWorldPoint(Vector3 _worldPosition)
    {
        float percentX = (_worldPosition.x + (gridWorldSize.x / 2)) / gridWorldSize.x;
        float percentY = (_worldPosition.z + (gridWorldSize.y / 2)) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public List<Node> path;

    private void OnDrawGizmos()
    {
        if (path != null)
        {
            foreach (var item in path)
            {
                Debug.Log("Path item: " + item);
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireCube(new Vector3(item.gridX, 0, item.gridY), Vector3.one);
            }
            Debug.Log("Path nodes count: " + path.Count);
        }
        //Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
        //if (grid != null && player != null)
        //{
        //    Node playerNode = GetNodeFromWorldPoint(player.position);
        //    foreach (Node n in grid)
        //    {
        //        //Gizmos.color = (n.isWalkable) ? Color.green : Color.red;
        //        if (path != null)
        //        {
        //            if (path.Contains(n))
        //            {
        //                Gizmos.color = Color.yellow;
        //                Gizmos.DrawWireCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
        //            }
        //        }
        //        if (playerNode == n) Gizmos.color = Color.magenta;
        //        //Gizmos.DrawWireCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));

        //    }
        //}
    }
}

//[System.Serializable]
//public class TerrainType
//{
//    public LayerMask terrainMask;
//    public int terrainPenalty;
//}
