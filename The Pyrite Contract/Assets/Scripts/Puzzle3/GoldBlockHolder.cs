using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBlockHolder : MonoBehaviour
{
    [SerializeField] GameObject walkway;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("GoldItem"))
        {
            walkway.SetActive(true);
            Destroy(other.gameObject);
         
            Destroy(gameObject);

        }
    }




}
