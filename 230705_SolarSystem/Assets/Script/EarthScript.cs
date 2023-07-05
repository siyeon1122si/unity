using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    public GameObject targetSun = default;

    public float EarthSpeed = 30.0f;

    public float rotationSpeed = 1.0f;
    private Vector3 EarthRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(targetSun.transform.position, Vector3.down, EarthSpeed * Time.deltaTime);
        EarthRotation.y = (rotationSpeed * Time.deltaTime);
        transform.Rotate(EarthRotation);
    }
}