using System.Collections;
using System.Collections.Generic;
using Audio;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Tools;
using UnityEngine.UI;

[DefaultExecutionOrder(-2)]
public class CanvasManager : StaticInstance<CanvasManager>
{
    [SerializeField]
    private GameObject _endScreen;
    // [Header("EndScreenDotween")]
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI youDeathTmp;
    [SerializeField] private TextMeshProUGUI butTmp;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        LevelManager.Instance.OnLevelEnd += ShowEndScreen;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        //LevelManager.Instance.OnLevelEnd -= ShowEndScreen;
    }

    private Sequence seq;
    
    private  void ShowEndScreen()
    {
        if (seq != null)
            return;
        youDeathTmp.text = "";
        butTmp.text = "";
        background.color = new Color(0, 0, 0, 0);
        _endScreen.SetActive(true);
        seq = DOTween.Sequence();
        seq.AppendInterval(.5f);
        seq.Append(DOTween.ToAlpha(() => background.color, x => background.color = x, 1, .5f));

        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Т", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты ", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты м", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты мё", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты мёр", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты мёрт", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Ты мёртв", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.AppendInterval(.5f);
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "Н", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "Но", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "Но.", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "Но..", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "Но...", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        
        seq.AppendInterval(.3f).OnComplete(() =>
        {
            SceneLoader.LoadNext();
        });
    }


}
