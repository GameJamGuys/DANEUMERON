using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MonologueTrigger : MonoBehaviour
{
    [SerializeField] private Monologue monologue;
    [SerializeField] private UnityEvent actionIfEndMonologue;
    [SerializeField] private Text monologueField;
    [SerializeField] private bool isTriggerOnStart;

    private Animator _animator;
    private bool _isOpen;

    public Monologue Monologue
    {
        get => monologue;
        set => monologue = value;
    }

    public Text MonologueField
    {
        get => monologueField;
        set => monologueField = value;
    }

    public Animator Animator
    {
        get => _animator;
        set => _animator = value;
    }

    public bool IsOpen
    {
        get => _isOpen;
        set => _isOpen = value;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (isTriggerOnStart)
        {
            TriggerMonologue();
        }
    }

    public void TriggerMonologue()
    {
        gameObject.SetActive(true);
        if (!_isOpen && !MonologueManager.Instance.IsMonologue)
        {
            gameObject.SetActive(true);
            MonologueManager.Instance.StartMonologue(this);
            _isOpen = true;
        }
    }

    public void EndMonologue()
    {
        actionIfEndMonologue?.Invoke();
    }
}

[Serializable]
public class Monologue
{
    [TextArea(3, 10)] [SerializeField] private string[] sentences;

    public string[] Sentences
    {
        get => sentences;
        set => sentences = value;
    }
}