using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralNPCDialoge : MonoBehaviour
{
    [SerializeField]
    int EndRepetition;

    public InteractKey interactKey;

    public EngageDialog engageDialog;

    public DialogCollection dialogCollection;

    public TextMeshProUGUI dialogText;

    public int lineNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (interactKey == null)
        {
            Debug.LogWarning("interact key not assigned");
        }
        if (dialogText == null)
        {
            Debug.LogWarning("Text not assigned");
        }
        if (dialogCollection == null)
        {
            Debug.LogWarning("dialog collection not assigned");
        }
        if (engageDialog == null)
        {
            Debug.LogWarning("engage dialog not assigned");
        }

        lineNumber = 0;

        EndRepetition = EndRepetition + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (engageDialog.hasStartedDialog == true && engageDialog.playerIsInTrigger == true)
        {
            if (Input.GetKeyDown(interactKey.InteractionKey))
            {
                lineNumber += 1;
            }
        }
        if (lineNumber > 20)
        {
            lineNumber = 20;
        }
        DialogLines(dialogCollection.dialogID1, dialogCollection.dialogID2, dialogCollection.dialogID3, dialogCollection.dialogID4, dialogCollection.dialogID5, dialogCollection.dialogID6, dialogCollection.dialogID7, dialogCollection.dialogID8, dialogCollection.dialogID9, dialogCollection.dialogID10, dialogCollection.dialogID11, dialogCollection.dialogID12, dialogCollection.dialogID13, dialogCollection.dialogID14, dialogCollection.dialogID15, dialogCollection.dialogID16, dialogCollection.dialogID17, dialogCollection.dialogID18, dialogCollection.dialogID19, dialogCollection.dialogID20, lineNumber);
    }

    void DialogLines(string line1, string line2, string line3, string line4, string line5, string line6, string line7, string line8, string line9, string line10, string line11, string line12, string line13, string line14, string line15, string line16, string line17, string line18, string line19, string line20, int lineNumberForFunktion)
    {
        if (lineNumberForFunktion == 1)
        {
            if (line1 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line1;
        }if (lineNumberForFunktion == 2)
        {
            if (line2 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line2;
        }if (lineNumberForFunktion == 3)
        {
            if (line3 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line3;
        }if (lineNumberForFunktion == 4)
        {
            if (line4 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line4;
        }if (lineNumberForFunktion == 5)
        {
            if (line5 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line5;
        }if (lineNumberForFunktion == 6)
        {
            if (line6 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line6;
        }if (lineNumberForFunktion == 7)
        {
            if (line7 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line7;
        }if (lineNumberForFunktion == 8)
        {
            if (line8 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line8;
        }if (lineNumberForFunktion == 9)
        {
            if (line9 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line9;
        }if (lineNumberForFunktion == 10)
        {
            if (line10 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line10;
        }if (lineNumberForFunktion == 11)
        {
            if (line11 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line11;
        }if (lineNumberForFunktion == 12)
        {
            if (line12 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line12;
        }if (lineNumberForFunktion == 13)
        {
            if (line13 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line13;
        }if (lineNumberForFunktion == 14)
        {
            if (line14 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line14;
        }if (lineNumberForFunktion == 15)
        {
            if (line15 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line15;
        }if (lineNumberForFunktion == 16)
        {
            if (line16 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line16;
        }if (lineNumberForFunktion == 17)
        {
            if (line17 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line17;
        }if (lineNumberForFunktion == 18)
        {
            if (line18 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line18;
        }if (lineNumberForFunktion == 19)
        {
            if (line19 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line19;
        }if (lineNumberForFunktion == 20)
        {
            if (line20 == "")
            {
                engageDialog.hasStartedDialog = false;
                lineNumber -= EndRepetition;
                return;
            }
            dialogText.text = line20;
        }
    }
}
