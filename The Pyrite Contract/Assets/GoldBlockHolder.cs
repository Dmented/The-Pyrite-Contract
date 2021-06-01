using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBlockHolder : MonoBehaviour
{
    [SerializeField] GameObject walkway;
   
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
        if (other.gameObject.tag == ("GoldItem"))
        {
            print("got it");
            walkway.SetActive (true);



        }
        
    }
}
