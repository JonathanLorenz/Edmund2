using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : Interactable
{
    public GameObject[] objectsLinkedToWallButton;
    public Light triggerLight;
    public AudioSource sfx;
    bool triggerOn;
    public bool fake;

    private void Start()
    {
        triggerOn = false;
        triggerLight.color = Color.red;
    }

    public override void Interact()
    {
        if (fake)
        {
            print("Interacting with FAKE wall button.");
            sfx.Play();
        }
        else
        {
            print("Interacting with wall button.");

            if (!triggerOn)
            {
                foreach (GameObject objectLinked in objectsLinkedToWallButton)
                    objectLinked.SetActive(false);
                triggerLight.color = Color.green;
                triggerOn = true;
                sfx.Play();
            }
            else
            {
                foreach (GameObject objectLinked in objectsLinkedToWallButton)
                    objectLinked.SetActive(true);
                triggerLight.color = Color.red;
                triggerOn = false;
                sfx.Play();
            }
        }
    }
}
