using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;

    public ParticleSystem explosion;
    public void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Enemy"))
        {
            Instantiate(explosion, other.transform.position, Quaternion.identity, null);
            Destroy(other.gameObject);
            Destroy(gameObject);

            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.score += 10;
        }
      
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * new Vector3(0f, 0f, 1f);

        
    }
}
