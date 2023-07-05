using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    public GameObject targetEarth = default;

    public float MoonSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(targetEarth.transform.position, Vector3.down, MoonSpeed * Time.deltaTime);
    }
}