using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using Object = UnityEngine.Object;


[RequireComponent(typeof(TMP_Text))]
public class TypingEffect : MonoBehaviour
{
    //all of this is copied from a youtube tutorial

    private TMP_Text TextBox;
    private int currentlyVisibleCharacterIndex;
    private bool readyForNewText = true;

    private Coroutine TypeWriterCoroutine;

    private WaitForSeconds _basicDelay;
    private WaitForSeconds _interpuctuationDelay;

    [Header("TypeWriter settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float interpuctuationDelay = 0.5f;


    public bool IsCurrentlySkipping { get; private set; }
    private WaitForSeconds _skippingDelay;

    [Header("Skipping options")]
    [SerializeField] private bool quickSkip;
    [SerializeField][Min(1)] private int SkipSpeedup = 5;

    private WaitForSeconds _textBoxFulleventDelay;
    [SerializeField][Range(0.1f, 0.5f)] private float sendDoneDelay = 0.25f;

    public static event Action CompleteTextRevealed;
    public static event Action<char> CharactersRevealed;

    private void Awake()
    {
        TextBox = GetComponent<TMP_Text>();

        _basicDelay = new WaitForSeconds(1 / charactersPerSecond);
        _interpuctuationDelay = new WaitForSeconds(interpuctuationDelay);

        _skippingDelay = new WaitForSeconds(1 / (charactersPerSecond * SkipSpeedup));
        _textBoxFulleventDelay = new WaitForSeconds(sendDoneDelay);
    }
    private void OnEnable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(PrepareForNewText);
    }
    private void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(PrepareForNewText);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (TextBox.maxVisibleCharacters != TextBox.textInfo.characterCount - 1)
            {
                Skip();
            }
        }
    }

    public void PrepareForNewText(Object obj)
    {
        if (!readyForNewText)
        {
            return;
        }

        readyForNewText = false;

        if (TypeWriterCoroutine != null)
        {
            StopCoroutine(TypeWriterCoroutine);
        }
        else { 
            TextBox.maxVisibleCharacters = 0;
            currentlyVisibleCharacterIndex = 0;

            TypeWriterCoroutine = StartCoroutine(routine: TypeWriter());
        }
    }
    void Skip()
    {
        if (IsCurrentlySkipping)
        {
            return;
        }
        
        IsCurrentlySkipping = true;

        if (!quickSkip)
        {
            StartCoroutine(routine: SkipSpeedupReset());
            return;
        }

        StopCoroutine(TypeWriterCoroutine);
        TextBox.maxVisibleCharacters = TextBox.textInfo.characterCount;
        readyForNewText = true;
        CompleteTextRevealed?.Invoke();
    }
    private IEnumerator TypeWriter()
    {
        TMP_TextInfo textInfo = TextBox.textInfo;

        while(currentlyVisibleCharacterIndex < textInfo.characterCount + 1)
        {
            int lastCharacterIndex = textInfo.characterCount - 1;

            if (currentlyVisibleCharacterIndex == lastCharacterIndex)
            {
                TextBox.maxVisibleCharacters++;
                yield return _textBoxFulleventDelay;
                CompleteTextRevealed?.Invoke();
                readyForNewText = true;
                yield break;
            }


            char character = textInfo.characterInfo[currentlyVisibleCharacterIndex].character;

            TextBox.maxVisibleCharacters++;

            if(!IsCurrentlySkipping && character == '.' || character == '?' || character == '!' || character == ',' || character == ':' || character == ';' || character == '-')
            {
                yield return _interpuctuationDelay;
            }
            else
            {
                yield return IsCurrentlySkipping ? _skippingDelay : _basicDelay;
            }

            CharactersRevealed?.Invoke(character);
            currentlyVisibleCharacterIndex++;
        }
    }
    private IEnumerator SkipSpeedupReset()
    {
        yield return new WaitUntil(() => TextBox.maxVisibleCharacters == TextBox.textInfo.characterCount - 1);
        IsCurrentlySkipping = false;
    }
}
