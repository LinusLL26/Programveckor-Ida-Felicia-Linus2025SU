using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class TypingEffect : MonoBehaviour
{
    //all of this is copied from a youtube tutorial

    private TMP_Text TextBox;

    //prototype text
    [Header("test string")]
    
    [SerializeField] string testingText;
   
    private int currentlyVisibleCharactersIndex;

    private Coroutine TypeWriterCoroutine;

    private WaitForSeconds BaseDelay;
    private WaitForSeconds InterPunctuationDelay;

    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float extraInterPunctuationDelay = 0.5f;

    

    private void Awake()
    {
        TextBox = GetComponent<TMP_Text>();

        BaseDelay = new WaitForSeconds(1 / charactersPerSecond);
        InterPunctuationDelay = new WaitForSeconds(extraInterPunctuationDelay);

    }
    private void Start()
    {
        SetText(testingText);
    }
    public void SetText(string text)
    {
        if (TypeWriterCoroutine == null)
        {
            StopCoroutine(TypeWriterCoroutine);
        }

        TextBox.text = text;
        TextBox.maxVisibleCharacters = 0;
        currentlyVisibleCharactersIndex = 0;

        TypeWriterCoroutine = StartCoroutine(routine: TypeWriter());
    }
    private IEnumerator TypeWriter()
    {
        TMP_TextInfo textInfo = TextBox.textInfo;

        while (currentlyVisibleCharactersIndex < textInfo.characterCount + 1)
        {
            char character = textInfo.characterInfo[currentlyVisibleCharactersIndex].character;

            TextBox.maxVisibleCharacters++;

            if (character == '.' || character == '?' || character == '!' || character == ',' || character == ':' || character == ';' || character == '-')
            {
                yield return InterPunctuationDelay;
            }
            else
            {
                yield return BaseDelay;
            }

            currentlyVisibleCharactersIndex++;
        }
    }
}
