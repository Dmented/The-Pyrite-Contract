using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle1
{
    public class Puzzle1_Lever : MonoBehaviour
    {
        [SerializeField] Animator leverAnimator;

        public bool puzzle1Active = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerStay(Collider other)

        {

            if (other.gameObject.tag == "Player" && !puzzle1Active)
            {
                if (Input.GetButton("Fire1"))
                {
                    Activate();
                }
            }
        }

        public void Activate()
        {

            leverAnimator.Play("LeverUp");
            puzzle1Active = true;
        }

        public bool Activated()
        {
            return puzzle1Active;
        }


    }
}