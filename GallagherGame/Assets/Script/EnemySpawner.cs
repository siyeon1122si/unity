using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float speedTime = 0f;
    public float speedTimeMax = 5f;

    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedTime += Time.deltaTime;

        if ( speedTime >= speedTimeMax )
        {
            Instantiate(Enemy, transform.position, Quaternion.identity, null);
            speedTime = 0f;
        }
    }
}
