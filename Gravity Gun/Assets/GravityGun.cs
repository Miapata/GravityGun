using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public GameObject gravityHolder;
    public bool hasItem;

    private GameObject toSlerp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycast;
        if (Input.GetMouseButton(0))
        {
            Physics.Raycast(gravityHolder.transform.position, transform.forward, out raycast);
            if (raycast.collider != null)
            {
                if (raycast.collider.tag == "Object_Interactable")
                {
                    toSlerp = raycast.collider.gameObject;
                }
            }



        }

        if (toSlerp == null)
            return;
        LerpObject(toSlerp);
    }

    void LerpObject(GameObject hitGameObject)
    {
        if (hasItem == true)
            return;
        else
        {
            hitGameObject.transform.position = Vector3.Slerp(transform.position, gravityHolder.transform.position,  1f);
        }
    }
}
