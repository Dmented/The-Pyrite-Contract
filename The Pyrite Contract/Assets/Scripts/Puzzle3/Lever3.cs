using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{

    [SerializeField] Animator leverAnimator;
    [SerializeField] GameObject EasyAccess;
    [SerializeField] GameObject lastPuzzle;

    private void OnTriggerStay(Collider other)


    {

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButton("Fire1"))
            {
                Activate();
            }
        }
    }

    void Activate()
    {
        leverAnimator.Play("LeverUp");
        EasyAccess.SetActive(true);
        lastPuzzle.SetActive(true);

    }
}

