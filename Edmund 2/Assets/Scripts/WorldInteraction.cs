﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;
    Animator playerAnimator;
    Scene currentScene;
    Collider playerCollider;
    public AudioSource deathSfx;
    public Image fadePanel;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        currentScene = SceneManager.GetActiveScene();
        playerAnimator = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0f;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //next scene trigger
        if (other.tag == "Next Scene Trigger")
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        //spikes trigger
        else if (other.tag == "Spikes Trigger")
        {
            StopsPlayer();
        }
        //spikes or killbox
        else if (other.tag == "Spikes")
        {
            KillPlayer();
            StartCoroutine(WaitAndReload(3f));
        }
        else if (other.tag == "Boulder")
        {
            playerCollider.enabled = false;
            playerAnimator.SetTrigger("Flattened By Boulder");
            StopsPlayer();
            KillPlayer();
            StartCoroutine(WaitAndReload(3f));
        }
    }

    void StopsPlayer()
    {
        playerAgent.isStopped = true;
    }

    void KillPlayer()
    {
        deathSfx.Play();
        fadePanel.CrossFadeAlpha(1f, 3f, false);
    }

    IEnumerator WaitAndReload (float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
