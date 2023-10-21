using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Core.Managers
{
    public class NaviManager : MonoBehaviour
    {
        [SerializeField]
        private int _numberOfLevels = 1;
        private int _level;

        private void Start()
        {
            _level = SceneLoader.GetScene();
        }

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
            if (_level == _numberOfLevels)
                BackToMenu();
            else
                SceneLoader.LoadNext();
        }
    }
}
