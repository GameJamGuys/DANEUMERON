using System;
using DG.Tweening;
using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class BreakableObject : MonoBehaviour
    {
        [SerializeField] private Transform glare;
        [SerializeField] private Transform end;
        [SerializeField] private float duration;

        private void Awake()
        {
            var seq = DOTween.Sequence();
            seq.Append(glare.DOMove(end.position, duration));
            seq.AppendInterval(1);
            seq.SetLoops(-1);
        }

        public void Broke()
        {
            Destroy(gameObject);
        }
    }
}