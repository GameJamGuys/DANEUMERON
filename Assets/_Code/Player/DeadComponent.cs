using System;
using UnityEngine;
using TarodevController;

namespace _Code
{
    public class DeadComponent : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator anim;
        [SerializeField] private GameObject death;

        private void Start()
        {
            if(anim == null)
                anim = GetComponentInChildren<PlayerAnimator>();
        }

        public void Dead()
        {
            print("Player dead");
            anim.OnDead();
            death.gameObject.SetActive(true);
            LevelManager.Instance.EndLevel();
        }

    }
}