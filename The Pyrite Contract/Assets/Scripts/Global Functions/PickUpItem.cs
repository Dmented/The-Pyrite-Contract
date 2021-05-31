using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] float pickupRange = 5;
    [SerializeField] float objectDrag = 10;
    [SerializeField] float yeetfactor = 5;
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform playerHoldLocation;
    [SerializeField] Transform objectsParent;
    [SerializeField] GameObject holdLocationBoXCollider;
    [SerializeField] BoxCollider playerCollider;
    GameObject ItemHeld;


    private void Update()
    {
        PickupAndMoveObject();
        PutItemDown();
        ThrowObject();
       
    }

    private void PickupAndMoveObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ItemHeld == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }

            }

        }
    }

    private void PutItemDown()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (ItemHeld != null)
            {
                DropObject();
            }

        }
    }


    private void ThrowObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (ItemHeld != null)
            {
                LaunchObject();
            }
        }
    }



    void PickupObject(GameObject pickupObj)
    {
        if (pickupObj.GetComponent<Rigidbody>())
        {
            Rigidbody ObjectsRigidbody = pickupObj.GetComponent<Rigidbody>();

            ObjectsRigidbody.useGravity = false;
            ObjectsRigidbody.drag = objectDrag;
            
            ObjectsRigidbody.transform.parent = playerHoldLocation;
            holdLocationBoXCollider.GetComponent<BoxCollider>().enabled = true;
            ObjectsRigidbody.transform.position = playerHoldLocation.transform.position;
            ObjectsRigidbody.transform.rotation = playerHoldLocation.transform.rotation;
            ObjectsRigidbody.freezeRotation = true;
            ItemHeld = pickupObj;
        }

    }

    void LaunchObject()
    {
        ItemHeld.GetComponent<Rigidbody>().velocity = transform.forward * yeetfactor;

        DropObject();
    }

    void DropObject()
    {
        Rigidbody heldItem = ItemHeld.GetComponent<Rigidbody>();

        heldItem.useGravity = true;
        heldItem.drag = 1;
        heldItem.freezeRotation = false;
     
        holdLocationBoXCollider.GetComponent<BoxCollider>().enabled = false;


        ItemHeld.transform.parent = objectsParent;
        ItemHeld = null;

    }

    

  


}
