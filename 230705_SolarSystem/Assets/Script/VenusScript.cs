using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusScript: MonoBehaviour
{
    public GameObject targetSun = default;

    public float VenusSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(targetSun.transform.position, Vector3.down, VenusSpeed * Time.deltaTime);
    }
}
