using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    { 
        //transform.position += Time.deltaTime * speed * new Vector3( 0f, 0f, -1f );
    }
}
