﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{

    public bool isWalkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;
    int heapIndex;
    [SerializeField] List<Node> neighbors;

    public Node(bool _isWalkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        isWalkable = _isWalkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    //public void InitNode(bool _isWalkable, Vector3 _worldPos, int _gridX, int _gridY)
    //{
    //    isWalkable = _isWalkable;
    //    worldPosition = _worldPos;
    //    gridX = _gridX;
    //    gridY = _gridY;
    //}

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int HeapIndex1 { get => heapIndex; set => heapIndex = value; }
    public List<Node> Neighbors { get => neighbors; set => neighbors = value; }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}
