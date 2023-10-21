using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

namespace _Code
{
    public class BombLogic : MonoBehaviour
    {
        [SerializeField]
        int boomTime = 5;
        [Space]
        [SerializeField]
        TMP_Text timeText;
        [SerializeField]
        GameObject fitil;
        [SerializeField]
        ExplodeArea explode;

        private void Start()
        {
            timeText.text = boomTime.ToString();
            fitil.SetActive(false);
        }

        public void LightUp(int timeToBoom = 5)
        {
            boomTime = timeToBoom;

            fitil.SetActive(true);
            StartCount();
        }

        async void StartCount()
        {
            for (int i = boomTime - 1; i >= 0; i--)
            {
                await UniTask.Delay(1000);
                timeText.text = i.ToString();
            }
            Explode();
        }

        async void Explode()
        {
            explode.gameObject.SetActive(true);
            await UniTask.Delay(300);
            Destroy(gameObject);
        }
    }

}