using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public GameObject playerTransform;
    public Rigidbody rigid;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rigid.MovePosition(transform.position + (transform.forward * z ) + (transform.right * x ));
        if (Input.GetKeyDown(KeyCode.Space))
            rigid.AddForce(transform.up * jumpForce);
    }

}

