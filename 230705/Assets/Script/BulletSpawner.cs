using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target = default;
    private float spawnRate = default;
    public float timeAfterSpawn = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PigControler>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if ( timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            transform.LookAt(target);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
