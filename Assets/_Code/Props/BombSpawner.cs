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
        [SerializeField] private bool isSpawnByCooldown;

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
        }

        public void SpawnBomb()
        {
            var newBomb = Instantiate(bomb, spawnPoint.transform);
            newBomb.LightUp();
        }
    }
}