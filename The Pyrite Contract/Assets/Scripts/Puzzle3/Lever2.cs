using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{

    [SerializeField] Animator leverAnimator;
    [SerializeField] GameObject lastSwitch;

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
        lastSwitch.SetActive(true);

    }
}

