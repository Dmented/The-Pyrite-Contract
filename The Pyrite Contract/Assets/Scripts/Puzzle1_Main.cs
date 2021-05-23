using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Puzzle1
{
    public class Puzzle1_Main : MonoBehaviour

    {


        [SerializeField] GameObject lever;
        [SerializeField] GameObject[] floortiles;
        [SerializeField] bool[] activeTile;
        // [SerializeField] GameObject[] triggers;
        public bool floorActive = false;
        bool tileActive = false;


        // Start is called before the first frame update

        private void Awake()
        {

        }

        void Start()
        {
        }


        // Update is called once per frame
        void Update()
        {

            setFloorActive();
        }

        void setFloorActive()
        {
            if (lever.GetComponent<Puzzle1_Lever>().Activated())
            {
                print("floor active");
                floorActive = true;

                //  print(floortiles[triggers]);
            }
        }

        void checkTileBool()
        {
            //if(floortiles[0].a)
        }





    }
}