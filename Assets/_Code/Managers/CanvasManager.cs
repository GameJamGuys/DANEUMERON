using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Tools;

public class CanvasManager : StaticInstance<CanvasManager>
{
    [SerializeField]
    private GameObject _endScreen;

    private void Start()
    {
        LevelManager.Instance.OnLevelEnd += ShowEndScreen;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelEnd -= ShowEndScreen;
    }

    private async void ShowEndScreen()
    {
        _endScreen.SetActive(true);
        await UniTask.Delay(1000);
        SceneLoader.LoadNext();
    }


}
