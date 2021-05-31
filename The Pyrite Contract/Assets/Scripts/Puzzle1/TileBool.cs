using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle1
{
    public class TileBool : MonoBehaviour
    {
        [SerializeField] bool active = false;
        [SerializeField] TileBool[] tilesInRange;
        [SerializeField] TileBool[] allTiles;
        [SerializeField] Material goldMat;
        [SerializeField] Material redMat;
        [SerializeField] GameObject lever;
        [SerializeField] GameObject key;
        [SerializeField] GameObject door;


        private void Start()
        {
            key.GetComponent<Key>().complete = false;
        }
       

        private void OnTriggerEnter(Collider other)
        {
            if (lever.GetComponent<Puzzle1_Lever>().Activated() && key.GetComponent<Key>().complete == false)
            {
                checkLocalActive();
            }
        }


        public void triggered()
        {
            active = !active;
        }

        public void Reset()
        {
            active = false;
        }

        void checkLocalActive()
        {
            for (int i = 0; i < tilesInRange.Length; i++)
            {
                tilesInRange[i].triggered();
                tilesInRange[i].changeColour();
            }
            triggered();
            changeColour();
            updateKey();
        }

        void changeColour()
        {
            if (active)
            {
                gameObject.GetComponentInParent<Renderer>().material = goldMat;
            }
            else
            {
                gameObject.GetComponentInParent<Renderer>().material = redMat;
            }
        }

        bool puzzleComplete()
        {
            for (int i = 0; i < allTiles.Length; i++)
            {
                if (allTiles[i].active == false)
                {
                    return false;
                }
            }
            return true;
        }

        void updateKey()
        {
            if (puzzleComplete())
            {
                key.GetComponent<Key>().complete = true;
                door.GetComponent<Puzzle1_Door>().ShowDoorway();
            }
            else
            {
                key.GetComponent<Key>().complete = false;
            }

        }



    }


}