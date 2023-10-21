using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

namespace _Code
{
    public class BombLogic : MonoBehaviour
    {
        [SerializeField]
        float boomTime = 5;
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
            boomTime -= 0.5f;
            for (float i = boomTime; i >= 0; i-=0.5f)
            {
                await UniTask.Delay(500);
                timeText.text = ((int)(i + 1)).ToString();
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