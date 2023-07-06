using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float speed = 1f;

    public Transform Pig;
    public Transform Ball;
    public Transform Nose;

    public float spawnTime = 0;
    public float spawnTimeMax = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Time.deltaTime * speed * new Vector3(0f, 1f, 0f);

        transform.LookAt(Pig);

        // 오브젝트 생성하는거임
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnTimeMax)
        {
            Instantiate(Ball, transform.position, transform.rotation, null);
            spawnTime = 0;
        }

    }
}
