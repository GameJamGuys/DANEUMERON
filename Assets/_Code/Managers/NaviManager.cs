using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Core.Managers
{
    public class NaviManager : MonoBehaviour
    {
        [SerializeField]
        private bool lastLevel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ReloadLevel();
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
            if (lastLevel)
                BackToMenu();
            else
                SceneLoader.LoadNext();
        }
    }
}
