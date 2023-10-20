using System;
using UnityEngine;
using TarodevController;

namespace _Code
{
    public class DeadComponent : MonoBehaviour
    {
        [SerializeField]
        private PlayerAnimator _anim;

        public void Dead()
        {
            print("Player dead");
            _anim.OnDead();
            LevelManager.Instance.EndLevel();
        }

    }
}