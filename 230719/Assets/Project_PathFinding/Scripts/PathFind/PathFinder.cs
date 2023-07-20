using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : GSingleton<PathFinder>
{
    #region ���� Ž���� ���� ����
    public GameObject sourceObj = default;
    public GameObject destinationObj = default;
    public MapBoard mapBoard = default;
    #endregion

    #region A* �˰������� �ִܰŸ��� ã�� ���� ����
    private List<AstarNode> aStarResultPath = default;
    private List<AstarNode> aStarOpenPath = default;
    private List<AstarNode> aStarClosePath = default;
    #endregion



    // ! ������� ������ ������ ���� ã�� �Լ�
    public void FindPath_Astar() 
    {
        StartCoroutine(DelayFindPath_Astar(0.4f));
    }



    // ! Ž�� �˰��� �����̸� �ɱ�
    private IEnumerator DelayFindPath_Astar(float delay_) 
    {
        // A* �˰����� ����ϱ� ���ؼ� Path list�� �ʱ�ȭ�Ѵ�.
        aStarOpenPath = new List<AstarNode>();
        aStarClosePath = new List<AstarNode>();
        aStarResultPath = new List<AstarNode>();

        TerrainController targetTerrain = default;

        // ������� �ε����� ���ؼ�, ����� ��带 ã�ƿ´�.
        string[] sourceObjNameParts = sourceObj.name.Split('_');
        int sourceIdx1D = -1;
        int.TryParse(
            sourceObjNameParts[sourceObjNameParts.Length - 1], out sourceIdx1D);
        targetTerrain = mapBoard.GetTerrain(sourceIdx1D);
        // ã�ƿ� ����� ��带 Open list�� �߰��Ѵ�.
        AstarNode targetNode = new AstarNode(targetTerrain, destinationObj);
        Add_AstarOpenList(targetNode);

        int loopIdx = 0;
        bool isFoundDestination = false;
        bool isNoWayToGo = false;
        // TODO: �˰��� �����۵� Ȯ�� �� ���ǹ� ������ ����
        // A* �˰������� ���� ã�� ���η���
        // while(loopIdx < 10) 
        while(isFoundDestination == false && isNoWayToGo == false) 
        {
            // { Open list�� ��ȸ�ؼ� ���� �ڽ�Ʈ�� ���� ��带 �����Ѵ�.
            AstarNode minCostNode = default;
            // ���� �ڽ�Ʈ�� ���� ��带 ã�� ����
            foreach(var terrainNode in aStarOpenPath) 
            {
                // ���� ���� �ڽ�Ʈ�� ��尡 ����ִ� ���
                if(minCostNode == default) 
                {
                    minCostNode = terrainNode;
                }
                // ���� ���� �ڽ�Ʈ�� ��尡 ĳ�̵Ǿ� �ִ� ���
                else 
                {
                    // terrainNode�� �� ���� �ڽ�Ʈ�� ���� ���
                    // minCostNode�� ������Ʈ�Ѵ�.
                    if(terrainNode.AstarF < minCostNode.AstarF) 
                    {
                        minCostNode = terrainNode;
                    }
                    else { continue; }
                }
            }
            // } Open list�� ��ȸ�ؼ� ���� �ڽ�Ʈ�� ���� ��带 �����Ѵ�.

            minCostNode.ShowCost_Astar();
            minCostNode.Terrain.SetTileActiveColor(RDefine.TileStatusColor.SEARCH);

            // ������ ��尡 �������� �����ߴ��� Ȯ���Ѵ�.
            bool isArriveDest = mapBoard.GetDistance2D(
                minCostNode.Terrain.gameObject, destinationObj).
                Equals(Vector2Int.zero);

            // ������ ��尡 �������� ������ ���
            if(isArriveDest)
            {
                // { �������� �����ߴٸ� aStarResultPath ����Ʈ�� �����Ѵ�.
                AstarNode resultNode = minCostNode;
                bool isSet_aStarResultPathOK = false;
                // ���� ��带 ã�� ���� ������ ��ȸ�ϴ� ����
                while(isSet_aStarResultPathOK == false) 
                {
                    aStarResultPath.Add(resultNode);
                    if(resultNode.AstarPrevNode == default ||
                        resultNode.AstarPrevNode == null) 
                    {
                        isSet_aStarResultPathOK = true;
                        break;
                    }
                    else { /* Do Nothing */ }

                    resultNode = resultNode.AstarPrevNode;
                }
                // } �������� �����ߴٸ� aStarResultPath ����Ʈ�� �����Ѵ�.

                // Open list�� Close list�� �����Ѵ�.
                aStarOpenPath.Clear();
                aStarClosePath.Clear();
                isFoundDestination = true;
                break;
            }
            // ������ ��尡 �������� �������� ���� ���
            else 
            {
                // { �������� �ʾҴٸ� ���� Ÿ���� �������� 4���� ��带 ã�ƿ´�.
                List<int> nextSearchIdx1Ds = mapBoard.
                    GetTileIdx2D_Around4Ways(minCostNode.Terrain.tileIdx2D);

                // ã�ƿ� ��� �߿��� �̵� ������ ���� Open list�� �߰��Ѵ�.
                AstarNode nextNode = default;
                // �̵� ������ ��带 Open list�� �߰��ϴ� ����
                foreach(var nextIdx1D in nextSearchIdx1Ds) 
                {
                    nextNode = new AstarNode(
                        mapBoard.GetTerrain(nextIdx1D), destinationObj);

                    if(nextNode.Terrain.IsPassible == false) { continue; }

                    Add_AstarOpenList(nextNode, minCostNode);
                }
                // } �������� �ʾҴٸ� ���� Ÿ���� �������� 4���� ��带 ã�ƿ´�.

                // Ž���� ���� ���� Close list�� �߰��ϰ�, Open list���� �����Ѵ�.
                // �̶�, Open list�� ��� �ִٸ� �� �̻� Ž���� �� �ִ� ����
                // �������� �ʴ� ���̴�.
                aStarClosePath.Add(minCostNode);
                aStarOpenPath.Remove(minCostNode);
                // �������� �������� ���ߴµ�, �� �̻� Ž���� �� �ִ� ���� ���� ���
                if(aStarOpenPath.IsValid() == false) 
                {
                    GFunc.LogWarning("[Warning] There are no more tiles to explore");
                    isNoWayToGo = true;
                }

                foreach(var tempNode in aStarOpenPath) 
                {
                    GFunc.Log($"Idx: {tempNode.Terrain.tileIdx1D}," +
                        $"Cost: {tempNode.AstarF}");
                }
            }


            loopIdx++;
            yield return new WaitForSeconds(delay_);
        }
    }



    // ! ����� ������ ��带 Open ����Ʈ�� �߰��ϴ� �Լ�
    private void Add_AstarOpenList(
        AstarNode targetTerrain_, AstarNode prevNode = default)
    {
        // Open ����Ʈ�� �߰��ϱ� ���� �˰��� ����� �����Ѵ�.
        Update_AstarCostToTerrain(targetTerrain_, prevNode);

        AstarNode closeNode = aStarClosePath.FindNode(targetTerrain_);
        // Close list�� �̹� Ž���� ���� ��ǥ�� ��尡 �����ϴ� ���
        if(closeNode != default && closeNode != null)
        {
            // �̹� Ž���� ���� ��ǥ�� ��尡 �����ϴ� ��쿡��
            // Open list�� �߰����� �ʴ´�.
            /* Do Nothing */
        }
        // ���� Ž���� ������ ���� ����� ���
        else 
        {
            AstarNode openedNode = aStarOpenPath.FindNode(targetTerrain_);
            // Open list �� ���� �߰��� ���� ���� ��ǥ�� ��尡 �����ϴ� ���
            if(openedNode != default && openedNode != null) 
            {
                // Ÿ�ٳ���� �ڽ�Ʈ�� �� ���� ��쿡�� Open list ���� ��带 ��ü�Ѵ�.
                // Ÿ�ٳ���� �ڽ�Ʈ�� �� ū ��쿡�� Open list �� �߰����� �ʴ´�.
                if(targetTerrain_.AstarF < openedNode.AstarF) 
                {
                    aStarOpenPath.Remove(openedNode);
                    aStarOpenPath.Add(targetTerrain_);
                }
                else { /* Do Nothing */ }
            }
            // Open list�� ���� �߰��� ���� ���� ��ǥ�� ��尡 ���� ���
            else 
            {
                aStarOpenPath.Add(targetTerrain_);
            }
        }
    }



    // ! Target ���� ������ Destination ���� ������ Distance�� Heuristic �� �����ϴ� �Լ�
    private void Update_AstarCostToTerrain(
        AstarNode targetNode, AstarNode prevNode)
    {
        // { Ÿ�� �������� Destination ������ 2D Ÿ�� �Ÿ��� ����ϴ� ����
        Vector2Int distance2D = mapBoard.GetDistance2D(
            targetNode.Terrain.gameObject, destinationObj);
        int totalDistance2D = distance2D.x + distance2D.y;

        // Heuristic�� �����Ÿ��� �����Ѵ�.
        Vector2 localDistance = destinationObj.transform.localPosition - 
            targetNode.Terrain.transform.localPosition;
        float heuristic = Mathf.Abs(localDistance.magnitude);
        // } Ÿ�� �������� Destination ������ 2D Ÿ�� �Ÿ��� ����ϴ� ����
        



        // { ���� ��尡 �����ϴ� ���, ���� ����� �ڽ�Ʈ�� �߰��ؼ� �����Ѵ�.
        if(prevNode == default || prevNode == null) { /* Do Nothing */ }
        else 
        {
            totalDistance2D = Mathf.RoundToInt(prevNode.AstarG + 1.0f);
        }
        targetNode.UpdateCost_Astar(
            totalDistance2D, heuristic, prevNode);
        // } ���� ��尡 �����ϴ� ���, ���� ����� �ڽ�Ʈ�� �߰��ؼ� �����Ѵ�.
    }
}
