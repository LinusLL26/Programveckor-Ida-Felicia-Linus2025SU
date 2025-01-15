using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralNPCDialoge : MonoBehaviour
{
    BoxCollider2D InteractionTrigger;

    public GameObject DialogBox;

    public GameObject TextObject;

    public TextMeshProUGUI DialogText;

    [SerializeField]
    int EndRepetition;

    public InteractKey interactKey;

    public DialogCollection dialogCollection;

    public int lineNumber;

    bool isCollider;

    public bool playerIsInTrigger;

    public bool hasStartedDialog;


    // Start is called before the first frame update
    void Start()
    {
        EndRepetition = EndRepetition + 1;

        if (interactKey == null)
        {
            Debug.LogWarning("interact key not assigned");
        }
        if (DialogText == null)
        {
            Debug.LogWarning("Text not assigned");
        }
        if (dialogCollection == null)
        {
            Debug.LogWarning("dialog collection not assigned");
        }

        InteractionTrigger = GetComponent<BoxCollider2D>();

        if (InteractionTrigger == null)
        {
            Debug.LogWarning("Trigger not present on NPC");
            return;
        }

        hasStartedDialog = false;

        DialogBox.SetActive(false);
        TextObject.SetActive(false);

        lineNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollider == true)
        {
            Debug.LogWarning("BoxCollider2D is not set to is trigger");
        }

        if (InteractionTrigger != null && playerIsInTrigger == true && Input.GetKeyDown(interactKey.InteractionKey))
        {
            hasStartedDialog = true;

            DialogBox.SetActive(true);
            TextObject.SetActive(true);

            lineNumber += 1;
            DialogLines(dialogCollection.dialogID1, dialogCollection.dialogID2, dialogCollection.dialogID3, dialogCollection.dialogID4, dialogCollection.dialogID5, dialogCollection.dialogID6, dialogCollection.dialogID7, dialogCollection.dialogID8, dialogCollection.dialogID9, dialogCollection.dialogID10, dialogCollection.dialogID11, dialogCollection.dialogID12, dialogCollection.dialogID13, dialogCollection.dialogID14, dialogCollection.dialogID15, dialogCollection.dialogID16, dialogCollection.dialogID17, dialogCollection.dialogID18, dialogCollection.dialogID19, dialogCollection.dialogID20, lineNumber);
           
        }

        if (hasStartedDialog == true && playerIsInTrigger == true)
        {
            if (Input.GetKeyDown(interactKey.InteractionKey))
            {
            }
        }
        if (lineNumber > 20)
        {
            lineNumber = 20;
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
        TextObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollider = true;
    }

    void DialogLines(string line1, string line2, string line3, string line4, string line5, string line6, string line7, string line8, string line9, string line10, string line11, string line12, string line13, string line14, string line15, string line16, string line17, string line18, string line19, string line20, int lineNumberForFunktion)
    {
        if (lineNumberForFunktion == 1)
        {
            if (line1 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line1);
        }if (lineNumberForFunktion == 2)
        {
            if (line2 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line2);
        }if (lineNumberForFunktion == 3)
        {
            if (line3 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line3);
        }if (lineNumberForFunktion == 4)
        {
            if (line4 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line4);
        }if (lineNumberForFunktion == 5)
        {
            if (line5 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line5);
        }if (lineNumberForFunktion == 6)
        {
            if (line6 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line6);
        }if (lineNumberForFunktion == 7)
        {
            if (line7 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line7);
        }if (lineNumberForFunktion == 8)
        {
            if (line8 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line8);
        }if (lineNumberForFunktion == 9)
        {
            if (line9 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line9);
        }if (lineNumberForFunktion == 10)
        {
            if (line10 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line10);
        }if (lineNumberForFunktion == 11)
        {
            if (line11 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line11);
        }if (lineNumberForFunktion == 12)
        {
            if (line12 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line12);
        }if (lineNumberForFunktion == 13)
        {
            if (line13 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line13);
        }if (lineNumberForFunktion == 14)
        {
            if (line14 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line14);
        }if (lineNumberForFunktion == 15)
        {
            if (line15 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line15);
        }if (lineNumberForFunktion == 16)
        {
            if (line16 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line16);
        }if (lineNumberForFunktion == 17)
        {
            if (line17 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line17);
        }if (lineNumberForFunktion == 18)
        {
            if (line18 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line18);
        }if (lineNumberForFunktion == 19)
        {
            if (line19 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line19);
        }if (lineNumberForFunktion == 20)
        {
            if (line20 == "")
            {
                hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            DialogText.SetText(line20);
        }
    }
}
