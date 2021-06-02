using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDetect : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] Material incorrect;
    [SerializeField] Material correct;
    [SerializeField] Material glass;
    [SerializeField] float alertDelay = 1.5f;
    [SerializeField] float upForce = 20f;
    [SerializeField] Transform noEntry;
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.transform.position = noEntry.position;
            StartCoroutine(simpleErrorTimer());
            return;
        }
        if (other.gameObject.tag != ("GoldItem"))
        {
            
            float randomSideForce = Random.Range(-10, 10);
            other.GetComponent<Rigidbody>().velocity = transform.up * upForce + transform.right * randomSideForce;
            StartCoroutine(simpleErrorTimer());
        }
        
        else
        {
            StartCoroutine(simpleCorrectTimer());
        }
    }
    IEnumerator simpleErrorTimer()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.GetComponent<Renderer>().material = incorrect;

        }
        yield return new WaitForSeconds(alertDelay);
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.GetComponent<Renderer>().material = glass;
        }
    }
    IEnumerator simpleCorrectTimer()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.GetComponent<Renderer>().material = correct;

        }
        yield return new WaitForSeconds(alertDelay);
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.GetComponent<Renderer>().material = glass;
        }
    }
}
