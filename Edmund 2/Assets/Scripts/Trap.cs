using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Animator[] objectsToAnimate;
    public AudioSource sfx;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player collided with spikes trigger.");
            foreach (Animator objectToAnimate in objectsToAnimate)
            {
                objectToAnimate.SetTrigger("Spikes Out Trigger");
                sfx.Play();
            }
        }
    }
}
