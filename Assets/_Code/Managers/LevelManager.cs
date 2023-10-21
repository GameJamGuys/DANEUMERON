using System;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class LevelManager : StaticInstance<LevelManager>
{

    public event Action OnLevelEnd;

    [HideInInspector]
    public int _level;

    private void Start()
    {
        _level = SceneLoader.GetScene();
    }

    public void EndLevel()
    {
        OnLevelEnd?.Invoke();
    }
}
