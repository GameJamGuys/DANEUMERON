using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : StaticInstance<LevelManager>
{

    public event Action OnLevelEnd;


    public void EndLevel()
    {
        OnLevelEnd?.Invoke();
    }
}
