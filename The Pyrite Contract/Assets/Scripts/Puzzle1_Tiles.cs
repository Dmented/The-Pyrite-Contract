using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Puzzle1
{
    public class Puzzle1_Tiles : MonoBehaviour
    {
        [SerializeField] GameObject lever;
        [SerializeField] Material goldMat;
        [SerializeField] Material redMat;
        public bool activeTile;
        //  [SerializeField] GameObject[] triggers;
        //   [SerializeField] Transform triggerGroup;
        //  int selectedPlatformNumber;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
           
            if (lever.GetComponent<Puzzle1_Lever>().Activated())
            {
                print("got this far...");
                if (other.gameObject.tag == "Player")
                {
                                      
                    gameObject.GetComponentInParent<Renderer>().material= goldMat;
                    activeTile = true;

                }
            }
        }
    }
}
