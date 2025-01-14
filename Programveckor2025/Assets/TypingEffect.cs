using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class TypingEffect : MonoBehaviour
{
    //all of this is copied from a youtube tutorial

    [Header("Test String")]
    [SerializeField] private string testString;

    private TMP_Text TextBox;
    private int currentlyVisibleCharacterIndex;

    private Coroutine TypeWriterCoroutine;

    private WaitForSeconds _basicDelay;
    private WaitForSeconds _interpuctuationdelay;

    [Header("TypeWriter settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float interpuctuationDelay = 0.5f;

    private void Awake()
    {
        TextBox = GetComponent<TMP_Text>();

        _basicDelay = new WaitForSeconds(1 / charactersPerSecond);
        _interpuctuationdelay = new WaitForSeconds(interpuctuationDelay);
    }
    private void Start()
    {
        
    }
    public void SetText(string text)
    {

    }
}
