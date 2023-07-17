using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCountroler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if ( Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("사과를 먹는 기능");
        //}
    }

    public void OnAppleEat()
    {
        Debug.Log("사과를 먹는 기능");
    }
}
