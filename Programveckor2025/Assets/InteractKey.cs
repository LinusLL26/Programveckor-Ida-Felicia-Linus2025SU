using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKey : MonoBehaviour
{
    public bool interacted;

    [SerializeField]
    KeyCode Interact;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Interact))
        {
            interacted = true;
            print("Player attempted to interact");
        }
        else
        {
            interacted = false;
        }
    }
}
