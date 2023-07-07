using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;

    public float speedTime = 0f;
    public float speedTimeMax = 5f;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * new Vector3(0f, 0f, -1f);

        speedTime += Time.deltaTime;

        if (speedTime >= speedTimeMax)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation, null);
            speedTime = 0f;
        }
    }
}
