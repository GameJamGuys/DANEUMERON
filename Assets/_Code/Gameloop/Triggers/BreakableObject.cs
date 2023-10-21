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
            glare.DOMove(end.position, duration).SetLoops(-1);
        }

        public void Broke()
        {
            Destroy(gameObject);
        }
    }
}