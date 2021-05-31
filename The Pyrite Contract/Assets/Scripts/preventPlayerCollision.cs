using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preventPlayerCollision : MonoBehaviour
{
    [SerializeField] Transform playerHoldLocation;
    Vector3 heldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void stopMovingWhenCarried()
    {
        
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag==("interactable") || other.gameObject.tag == ("GoldItem"))
        {
            other.transform.position = playerHoldLocation.transform.position;
            other.transform.rotation = playerHoldLocation.transform.rotation;
        }
    }
}
