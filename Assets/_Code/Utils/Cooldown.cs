using System;
using UnityEngine;

namespace _Code.Utils
{
    [Serializable]
    public class Cooldown
    {
        [SerializeField] private float valueOfCooldown;
        
        private float _timesUp;

        public Cooldown(float valueOfCooldown)
        {
            this.valueOfCooldown = valueOfCooldown;
        }

        public void Reset()
        {
            _timesUp = Time.time + valueOfCooldown;
        }

        public bool IsReady => _timesUp <= Time.time;
    }
}