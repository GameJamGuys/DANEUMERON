using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Utils;
using Audio;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    public static MonologueManager Instance;

    private Queue<string> _sentences;
    private bool _allowedShowNext;
    private MonologueTrigger _monologueTrigger;
    private bool _isMonologue;
    private bool _isAllText;
    private string _currentSentence;

    private Cooldown _cooldown;

    private static readonly int IsEndMonologueAnim = Animator.StringToHash("is-end");

    public bool IsMonologue
    {
        get => _isMonologue;
        set => _isMonologue = value;
    }

    private void Awake()
    {
        Instance = this;
        _sentences = new Queue<string>();
        _cooldown = new Cooldown(1.5f);
    }

    private void Update()
    {
        if (_cooldown.IsReady)
        {
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
                if (_isMonologue)
                {
                    if (_allowedShowNext)
                    {
                        ShowNextSentence();
                    }
                    else if (!_isAllText)
                    {
                        ShowAllText();
                    }
                }
            //}

            _cooldown.Reset();
        }
    }

    private void ShowAllText()
    {
        _isAllText = true;
        //StopCoroutine(ShowSentenceByLetter());
        _monologueTrigger.MonologueField.text = _currentSentence;
        _allowedShowNext = true;
    }

    public void StartMonologue(MonologueTrigger monologueTrigger)
    {
        _isAllText = false;
        _isMonologue = true;

        _monologueTrigger = monologueTrigger;

        _sentences.Clear();

        foreach (var sentence in _monologueTrigger.Monologue.Sentences)
        {
            _sentences.Enqueue(sentence);
        }

        ShowNextSentence();
    }

    private void ShowNextSentence()
    {
        _isAllText = false;
        _allowedShowNext = false;

        if (_sentences.Count == 0)
        {
            EndMonologue();
        }
        else
        {
            _currentSentence = _sentences.Dequeue();
            StartCoroutine(ShowSentenceByLetter());
        }
    }

    IEnumerator ShowSentenceByLetter()
    {
        _monologueTrigger.MonologueField.text = "";
        foreach (var letter in _currentSentence.ToCharArray())
        {
            if (!_isAllText)
            {
                AudioBox.Instance.Play("Type");
                _monologueTrigger.MonologueField.text += letter;
                yield return new WaitForSeconds(0.08f);
            }
            else
            {
                yield return null;
            }
        }

        yield return null;
        _allowedShowNext = true;
    }

    private void EndMonologue()
    {
        //_monologueTrigger.Animator.SetBool(IsEndMonologueAnim, true);
        _monologueTrigger.MonologueField.text = "";
        _monologueTrigger.IsOpen = false;
        _monologueTrigger.EndMonologue();
        _isMonologue = false;
    }
}