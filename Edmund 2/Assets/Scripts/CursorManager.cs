using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D mouseIconNormal;
    public Texture2D mouseIconInteractable;
    public Texture2D mouseIconFeet;

    private void Awake()
    {
        Cursor.SetCursor(mouseIconNormal, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                print("Mouse over object.");
                Cursor.SetCursor(mouseIconInteractable, Vector2.zero, CursorMode.Auto);
            }
            else if (interactedObject.tag == "Next Scene Trigger")
            {
                print("Mouse over next scene trigger.");
                Cursor.SetCursor(mouseIconFeet, Vector2.zero, CursorMode.Auto);
            }
            else Cursor.SetCursor(mouseIconNormal, Vector2.zero, CursorMode.Auto);
        }
        
    }
}
