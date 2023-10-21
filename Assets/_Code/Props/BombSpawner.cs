using System;
using _Code.Utils;
using UnityEngine;

namespace _Code.Traps
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private BombLogic bomb;
        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private Cooldown cooldown;
        [SerializeField] private float bombDuration = 5;
        [SerializeField] private bool isSpawnByCooldown;

        private Cooldown _restrictiveCooldown;
        private BombLogic _currentBomb;

        private void Start()
        {
            _restrictiveCooldown = new Cooldown(5f);
        }

        private void Update()
        {
            if (isSpawnByCooldown)
            {
                if (cooldown.IsReady)
                {
                    SpawnBomb();
                    cooldown.Reset();
                }
            }

            if (_restrictiveCooldown.IsReady)
            {
                _currentBomb = null;
            }
        }

        public void SpawnBomb()
        {
            if (_currentBomb ==  null)
            {
                var newBomb = Instantiate(bomb, spawnPoint.transform);
                newBomb.boomTime = bombDuration;
                newBomb.LightUp();
                _currentBomb = newBomb;
                _restrictiveCooldown.Reset();
            }
        }
    }
}