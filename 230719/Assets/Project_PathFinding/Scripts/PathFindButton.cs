using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindButton : MonoBehaviour
{
    // ! Find A* ��ư�� ���� ���
    public void OnClickAstarFindBtn() 
    {
        PathFinder.Instance.FindPath_Astar();
    }
}