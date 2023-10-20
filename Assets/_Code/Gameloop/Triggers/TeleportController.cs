using System;
using TarodevController;
using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class TeleportController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private Transform posA;
        [SerializeField] private Transform posB;

        private void Update()
        {
            if (player.transform.position.x < posA.position.x)
                player.transform.position = new Vector3(posB.position.x,player.transform.position.y,
                    player.transform.position.z);
            
            if (player.transform.position.x > posB.position.x)
                player.transform.position = new Vector3(posA.position.x,player.transform.position.y,
                    player.transform.position.z);
        }
    }
}