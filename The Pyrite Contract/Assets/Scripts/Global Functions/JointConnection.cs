using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointConnection : MonoBehaviour
{

    [SerializeField] float pickupRange = 5;

    [SerializeField] Rigidbody ItemHeld;
    [SerializeField] Rigidbody player;
    [SerializeField] ItemPickUP pickUpScript;
    [SerializeField] float yeetFactor = 15f;
    LayerMask layer = 1 << 7;


    RaycastHit hit;

    ItemPickUP currentPickup;
    private void Start()
    {
       
    }


    void Update()
    {
        PickUp();
        DropOrThrowObject();


        if (Input.GetMouseButtonUp(1))
        {
            DropOrThrowObject();
        }


    }

    private void PickUp()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, layer))

            {
                pickUpScript = hit.rigidbody.GetComponent<ItemPickUP>();
                pickUpScript.AddJoint();
                currentPickup = pickUpScript;

                PickupObject(currentPickup);

            }

        }
    }



    private void DropOrThrowObject()
    {
        if (Input.GetMouseButtonDown(1))
        {

            print(ItemHeld);
            DropObject();
            ItemHeld.GetComponent<Rigidbody>().velocity = transform.forward * yeetFactor;

        }
    }



    void PickupObject(ItemPickUP pickupObj)
    {

        pickupObj.Rigidbody.constraints = RigidbodyConstraints.None;
        pickupObj.Joint.connectedBody = player;
        ItemHeld = pickupObj.Rigidbody;

    }

    void DropObject()
    {
        if (currentPickup != null)
        {
            Rigidbody rb = currentPickup.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 20000, ForceMode.Force);
            currentPickup = null;
        }


    }


}
