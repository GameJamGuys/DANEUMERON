using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Core.Managers
{
    public class NaviManager : MonoBehaviour
    {
        public void BackToMenu()
        {
            SceneLoader.Load(0);
        }

        public void ReloadLevel()
        {
            SceneLoader.Reload();
        }

        public void NextLevel()
        {
            SceneLoader.LoadNext();
        }
    }
}
