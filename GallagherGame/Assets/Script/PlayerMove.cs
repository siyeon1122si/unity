using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;

    public GameObject bullet;

    public float speedTime = 0f;
    public float speedTimeMax = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        transform.position += Time.deltaTime * speed * new Vector3(moveH, 0f, moveV);;

        if ( Input.GetKey(KeyCode.Space))
        {
            speedTime += Time.deltaTime;

            if (speedTime >= speedTimeMax)
            {
                Instantiate(bullet, transform.position, bullet.transform.rotation, null);
                speedTime = 0f;
            }
        }
    }
}
