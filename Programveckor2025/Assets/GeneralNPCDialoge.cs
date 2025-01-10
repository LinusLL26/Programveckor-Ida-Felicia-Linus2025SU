using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralNPCDialoge : MonoBehaviour
{
    public InteractKey interactKey;

    public EngageDialog engageDialog;

    public DialogCollection dialogCollection;

    public TextMeshProUGUI dialogText;

    int lineNumber;

    // Start is called before the first frame update
    void Start()
    {
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
        if (engageDialog.hasStartedDialog != true && engageDialog.playerIsInTrigger != true)
        {
            lineNumber = 0;
        }
    }

    void DialogLines(string line1, string line2, string line3, string line4, string line5, string line6, string line7, string line8, string line9, string line10, string line11, string line12, string line13, string line14, string line15, string line16, string line17, string line18, string line19, string line20, int lineNumberForFunktion)
    {

    }
}
