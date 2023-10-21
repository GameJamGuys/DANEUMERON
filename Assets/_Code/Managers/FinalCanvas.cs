using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Tools;
using UnityEngine.UI;
using Audio;

public class FinalCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject _endScreen;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private TextMeshProUGUI youDeathTmp;
    [SerializeField] private TextMeshProUGUI butTmp;

    private Sequence seq;

    void Start()
    {
        LevelManager.Instance.OnLevelEnd += ShowEndScreen;

    }

    private void ShowEndScreen()
    {
        if (seq != null)
            return;

        youDeathTmp.text = "";
        butTmp.text = "";
        _endScreen.SetActive(true);
        seq = DOTween.Sequence();
        seq.AppendInterval(.5f);

        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "Д", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА ", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА Н", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ ", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ У", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ УМ", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ УМЕ", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ УМЕР", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ УМЕР ", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ УМЕР О", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => youDeathTmp.text, x => youDeathTmp.text = x, "ДА НЕ УМЕР ОН", .1f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));

        seq.AppendInterval(.6f);

        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в ", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в к", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в ко", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в кон", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в конц", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));
        seq.Append(DOTween.To(() => butTmp.text, x => butTmp.text = x, "в конце", .15f).OnStart(() =>
        {
            AudioBox.Instance.Play("Type");
        }));

        seq.AppendInterval(.3f).OnComplete(() =>
        {
            SceneLoader.LoadNext();
        });
    }
}
