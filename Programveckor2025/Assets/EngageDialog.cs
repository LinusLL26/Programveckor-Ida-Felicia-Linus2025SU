using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageDialog : MonoBehaviour
{
    public GameObject DialogBox;

    public GameObject DialogText;

    public bool hasStartedDialog;

    public InteractKey interactKey;

    BoxCollider2D InteractionTrigger;

    bool isCollider;

    public bool playerIsInTrigger;

    // Start is called before the first frame update
    void Start()
    {
        InteractionTrigger = GetComponent<BoxCollider2D>();

        if (InteractionTrigger == null)
        {
            Debug.LogWarning("Trigger not present on NPC");
            return;
        }

        hasStartedDialog = false;

        DialogBox.SetActive(false);
        DialogText.SetActive(false);
    }

    private void Update()
    {
        if (isCollider == true)
        {
            Debug.LogWarning("BoxCollider2D is not set to is trigger");
        }
       
        if (InteractionTrigger != null && playerIsInTrigger == true && Input.GetKeyDown(interactKey.InteractionKey))
        {
                hasStartedDialog = true;

                DialogBox.SetActive(true);
                DialogText.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        print("player walked into trigger");
        playerIsInTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("player exited trigger");
        playerIsInTrigger = false;

        DialogBox.SetActive(false);
        DialogText.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollider = true;
    }

}
