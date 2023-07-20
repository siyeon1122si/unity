using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarNode
{
    public TerrainController Terrain { get; private set; }
    public GameObject DestinationObj { get; private set; }

    // A* algorithm
    public float AstarF { get; private set; } = float.MaxValue;
    public float AstarG { get; private set; } = float.MaxValue;
    public float AstarH { get; private set; } = float.MaxValue;

    public AstarNode AstarPrevNode { get; private set; } = default;

    // AStarNode ������
    public AstarNode(TerrainController terrain_, GameObject destinationObj_) 
    {
        Terrain = terrain_;
        DestinationObj = destinationObj_;
    }





    // ! AStar �˰��� ����� ����� �����Ѵ�.
    public void UpdateCost_Astar(float gCost, float heuristic, 
        AstarNode prevNode) 
    {
        float aStarF = gCost + heuristic;

        // ���� ����� ����� �� ���� ��쿡�� ������Ʈ �Ѵ�.
        if(aStarF < AstarF) 
        {
            AstarG = gCost;
            AstarH = heuristic;
            AstarF = aStarF;

            AstarPrevNode = prevNode;
        }
        else { /*Do Nothing*/ }
    }





    // ! ������ ����� ����Ѵ�.
    public void ShowCost_Astar() 
    {
        GFunc.Log($"TileIdx1D: {Terrain.tileIdx1D}, " +
            $"F: {AstarF}, G: {AstarG}, H: {AstarH}");
    }
}
