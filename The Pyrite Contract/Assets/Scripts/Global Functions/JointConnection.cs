using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointConnection : MonoBehaviour
{

    [SerializeField] float pickupRange = 5;

    [SerializeField] GameObject ItemHeld;
    [SerializeField] Rigidbody player;
    [SerializeField] ItemPickUP pickUpScript;

    RaycastHit hit;

    ItemPickUP currentPickup;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            
           
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                pickUpScript.AddJoint();
                PickupObject(hit.rigidbody.GetComponent<ItemPickUP>());
            }

        }

        /*  if (Input.GetMouseButtonUp(1))
          {
              if (ItemHeld != null)
              {
                  dropObject();
                  ItemHeld = null;
              }
          }*/
    }

    /*  void dropObject()
      {
          this.GetComponent<FixedJoint>().connectedBody = null;
      }*/

    void PickupObject(ItemPickUP pickupObj)
    {

       /* if (currentPickup)
        {
            Debug.LogError($"Have already picked up {currentPickup.name}", this);
            return;
        }*/
        currentPickup = pickupObj;
        currentPickup.Rigidbody.constraints = RigidbodyConstraints.None;
        currentPickup.Joint.connectedBody = player;

    }


}
