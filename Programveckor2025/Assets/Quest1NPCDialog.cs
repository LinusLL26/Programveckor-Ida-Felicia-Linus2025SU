using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1NPCDialog : MonoBehaviour
{
    public GeneralNPCDialoge generalNPCDialoge;

    public bool hasCompletedQuest1;

    [SerializeField]
    int lineToCompleteQuest;

    // Start is called before the first frame update
    void Start()
    {
        hasCompletedQuest1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (generalNPCDialoge.lineNumber >= lineToCompleteQuest)
        {
            hasCompletedQuest1 = true;
        }
    }
}
