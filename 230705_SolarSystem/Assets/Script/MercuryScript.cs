using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercuryScript : MonoBehaviour
{
    public GameObject targetSun = default;

    public float MercurySpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(targetSun.transform.position, Vector3.down, MercurySpeed * Time.deltaTime);
    }
}
