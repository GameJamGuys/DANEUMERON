using _Code.Gameloop.Triggers;
using Audio;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

namespace _Code
{
    public class BombLogic : Teleportable
    {
        [SerializeField]
        public float boomTime = 5;
        [SerializeField]
        bool autoLight = false;
        [Space]
        [SerializeField]
        TMP_Text timeText;
        [SerializeField]
        GameObject fitil;
        [SerializeField]
        ExplodeArea explode;

        private void Start()
        {
            timeText.text = ((int)boomTime).ToString();
            fitil.SetActive(false);

            if (autoLight)
                LightUp();
        }

        public void LightUp(int timeToBoom = 5)
        {
            AudioBox.Instance.Play("Fitil");
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
            
            AudioBox.Instance.Stop("Fitil");
            AudioBox.Instance.Play("Exp");
            explode.gameObject.SetActive(true);
            await UniTask.Delay(300);
            Destroy(gameObject);
        }
    }

}