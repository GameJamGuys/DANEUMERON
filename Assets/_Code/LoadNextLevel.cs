using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code
{
    public class LoadNextLevel : MonoBehaviour
    {
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Реализовать переход на следующую сцену
        public void NextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}