using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{


    void Start()
    {

    }

    float mousex;
    float mousey;

    Quaternion RotationSpeed;
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        mousex = Input.GetAxis("Mouse X");
        mousey = Input.GetAxis("Mouse Y");

        RotationSpeed = Quaternion.Euler(-mousey, mousex, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, RotationSpeed, Speed * Time.deltaTime);
    }
}

