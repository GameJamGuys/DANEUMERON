using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Core.Managers
{
    public class NaviManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                ReloadLevel();

            if (Input.GetKeyDown(KeyCode.RightBracket))
                NextLevel();

            if (Input.GetKeyDown(KeyCode.LeftBracket))
                SceneLoader.LoadPrev();

        }

        public void BackToMenu()
        {
            print("Load Menu");
            SceneLoader.Load("Menu");
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
