using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;
    Scene currentScene;
    public AudioSource deathSfx;
    public Image fadePanel;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        currentScene = SceneManager.GetActiveScene();
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

        //spikes or killbox
        else if (other.tag == "Spikes Trigger")
        {
            StopsPlayer();
            deathSfx.Play();
            fadePanel.CrossFadeAlpha(1f, 3f, false);
            StartCoroutine(WaitABit(3f));
        }
    }

    void StopsPlayer()
    {
        playerAgent.isStopped = true;
    }

    IEnumerator WaitABit (float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
