using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMoveScript : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal"); // ����
        float moveV = Input.GetAxis("Vertical"); // ����

        transform.position += Time.deltaTime * moveSpeed * new Vector3(moveH, 0f, moveV);
    }
}
