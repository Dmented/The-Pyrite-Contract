using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDetector : MonoBehaviour
{
    [SerializeField] Transform boxForObjects;
    [SerializeField] GameObject wallToRemove;
    [SerializeField] int unitsToWin = 6;
    [SerializeField] Transform objectsParent;
    [SerializeField] Collider volumeCheck;
    [SerializeField] GameObject lever_2;
    public bool tubeComplete = false;
   

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ("GoldItem"))
        {
            other.transform.parent = boxForObjects;
            if(boxForObjects.childCount >= unitsToWin)
            {
                wallToRemove.SetActive(false);
                volumeCheck.enabled = false;
                tubeComplete = true;
                lever_2.SetActive(true);

            }          
        }     
        

    }

  
}
