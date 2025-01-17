using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1NPCDialog : MonoBehaviour
{
    public GeneralNPCDialoge generalNPCDialoge;
    public Time_System timeSystem; // Reference to the Time_System

    public bool hasCompletedQuest1;

    [SerializeField]
    int lineToCompleteQuest;

    void Start()
    {
        hasCompletedQuest1 = false;

        if (timeSystem == null)
        {
            timeSystem = FindObjectOfType<Time_System>(); // Find the Time_System if not assigned
        }
    }

  
    void Update()
    {

        if (generalNPCDialoge.lineNumber >= lineToCompleteQuest)
        {
            hasCompletedQuest1 = true;

            // Notify Time_System about the interaction and quest completion
            if (timeSystem != null)
            {
                timeSystem.RegisterNPCInteraction(hasCompletedQuest1);  
                Debug.Log("NPC interaction registered, quest completion status: " + hasCompletedQuest1);
            }
        }
    }
}
