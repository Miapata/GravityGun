using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public GameObject gravityHolder;
    public float gravityForce;
    public bool hasItem;
    public float lerpSpeed;
    public float grabDistance;
    private GameObject toSlerp;
    private Rigidbody slerpRigidbody;
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
            if (hasItem == true)
                return;
            Physics.Raycast(gravityHolder.transform.position, transform.forward, out raycast, grabDistance);
            if (raycast.collider != null)
            {
                if (raycast.collider.tag == "Object_Interactable")
                {
                    toSlerp = raycast.collider.gameObject;
                }
            }



        }

        if (Input.GetMouseButton(1))
        {
            if (hasItem == false)
                return;
            else
            {
                toSlerp.transform.parent = null;
                slerpRigidbody.isKinematic = false;
                toSlerp.GetComponent<Rigidbody>().AddForce(transform.forward * gravityForce, ForceMode.Impulse);
                toSlerp = null;
                hasItem = false;
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
            slerpRigidbody = hitGameObject.GetComponent<Rigidbody>();
            for (float t = 0.0f; t < lerpSpeed; t += Time.deltaTime)
            {
                hitGameObject.transform.position = Vector3.Slerp(hitGameObject.transform.position, gravityHolder.transform.position, lerpSpeed);
            }
            slerpRigidbody.isKinematic = true;
            hitGameObject.transform.parent = transform;
            hasItem = true;
        }
    }
}
