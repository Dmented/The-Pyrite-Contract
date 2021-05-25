using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Door : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] GameObject solidWall;
    [SerializeField] GameObject doorway;
    // Start is called before the first frame update

    public void ShowDoorway()
    {
        if(key.GetComponent<Key>().complete == true)
        {
            solidWall.SetActive(false);
            doorway.SetActive(true);
        }
    }
}
