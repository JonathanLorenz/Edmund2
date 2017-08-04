using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public Animator[] objectsToAnimate;
    public GameObject[] objectsToDisable;
    public GameObject[] objectsToEnable;
    public AudioSource sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //animer floorButton
            foreach (Animator objectToAnimate in objectsToAnimate)
            {
                objectToAnimate.SetTrigger("Walks On Floor Button");
                sfx.Play();
            }
            //desactiver objects
            foreach (GameObject objectToDisable in objectsToDisable)
                objectToDisable.SetActive(false);
            //activer objects
            foreach (GameObject objectToEnable in objectsToEnable)
                objectToEnable.SetActive(true);
        }
    }
}
