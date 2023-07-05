using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigControler : MonoBehaviour
{
    private Rigidbody pigRigid = default;
    public float speed = default;

    // Start is called before the first frame update
    void Start()
    {
        pigRigid = GetComponent<Rigidbody>();
    }   // Start()

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        pigRigid.velocity = newVelocity;
    }   // Update()

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }

}   // class PigControler
