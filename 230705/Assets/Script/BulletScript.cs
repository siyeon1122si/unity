using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Pig")) 
        {
            Debug.Log(" PIG와 충돌했나 ");

            PigControler pigControler = other.GetComponent<PigControler>();

            if ( pigControler != null)
            {
                pigControler.Die();
            }
        }
    }

}
