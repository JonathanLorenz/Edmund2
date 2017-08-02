using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : Interactable
{
    public string[] dialogue;
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Sign");
        print("Interacting with sign post.");
    }
}
