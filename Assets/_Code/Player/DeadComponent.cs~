using System;
using UnityEngine;
using TarodevController;

namespace _Code
{
    public class DeadComponent : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator anim;

        private void Start()
        {
            if(anim == null)
                anim = GetComponentInChildren<PlayerAnimator>();
        }

        public void Dead()
        {
            print("Player dead");
            anim.OnDead();
            LevelManager.Instance.EndLevel();
        }

    }
}