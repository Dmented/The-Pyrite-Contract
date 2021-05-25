using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle1
{
    public class Puzzle1_Lever : MonoBehaviour
    {
        [SerializeField] Animator leverAnimator;
        [SerializeField] TileBool[] allTiles;
        [SerializeField] Material defaultMat;
        [SerializeField] GameObject Key;

        public bool puzzle1Active = false;
        public bool reset = false;
        public bool complete;

        TileBool tileBool;

        private void Start()
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
            if (other.gameObject.tag == "Player" && puzzle1Active && Key.GetComponent<Key>().complete == false)
            {
                if (Input.GetButton("Fire1"))
                {
                    Reset();
                }
            }
        }

        public void Activate()
        {

            leverAnimator.Play("LeverUp");
            puzzle1Active = true;
        }

        public void Reset()
        {
            if (Activated())
            {
               
                leverAnimator.Play("LeverUp");

                for (int i = 0; i < allTiles.Length; i++)
                {                   
                        allTiles[i].Reset();
                        allTiles[i].gameObject.GetComponentInParent<Renderer>().material = defaultMat;                  
                }

            }
            else
            {
                return;
            }

        }


        public bool Activated()
        {
            return puzzle1Active;
        }

        public bool ResetPuzzle()
        {
            return reset;

        }


    }
}