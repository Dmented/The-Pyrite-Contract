using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointConnection : MonoBehaviour
{

    [SerializeField] float pickupRange = 5;

    public Rigidbody ItemHeld;
    [SerializeField] Rigidbody player;
    [SerializeField] ItemPickUP pickUpScript;
    [SerializeField] float yeetFactor = 15f;
    LayerMask layer = 1 << 7;


    RaycastHit hit;

    ItemPickUP currentPickup;

    bool inhand = false;
    private void Start()
    {

    }


    void Update()
    {
        PickUp();
        DropObject();
        ThrowObject();

    }

    private void PickUp()
    {
        if (Input.GetMouseButtonDown(0))
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



    private void ThrowObject()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (inhand)
            {
                print(ItemHeld);
                pickUpScript.breakJoint();
                currentPickup = null;
                ItemHeld.GetComponent<Rigidbody>().velocity = transform.forward * yeetFactor;

                inhand = false;
            }

        }
    }



    void PickupObject(ItemPickUP pickupObj)
    {

        pickupObj.Joint.connectedBody = player;
        ItemHeld = pickupObj.Rigidbody;
        inhand = true;

    }

    void DropObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (inhand)
            {
                pickUpScript.breakJoint();
                currentPickup = null;
                inhand = false;
            }

        }
    }


}
