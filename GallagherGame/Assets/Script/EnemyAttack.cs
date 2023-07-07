using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed = 1f;
    public GameManager manager;
    public ParticleSystem explosion;

    private void Start()
    {
        manager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion, other.transform.position, Quaternion.identity, null);

            manager.GameOver();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * new Vector3(0f, 0f, -1f);
    }
}
