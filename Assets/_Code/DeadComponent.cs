using System;
using UnityEngine;

namespace _Code
{
    [RequireComponent(typeof(Animator))]
    public class DeadComponent : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int IsDead = Animator.StringToHash("is-dead");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Dead()
        {
            _animator.SetTrigger(IsDead);
        }
    }
}