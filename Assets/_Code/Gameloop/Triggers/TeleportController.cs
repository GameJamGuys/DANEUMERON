using System;
using System.Collections.Generic;
using System.Linq;
using TarodevController;
using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class TeleportController : MonoBehaviour
    {
        [SerializeField] private List<Teleportable> teleportables = new List<Teleportable>();
        [SerializeField] private Transform posA;
        [SerializeField] private Transform posB;

        private void Awake()
        {
            teleportables = FindObjectsOfType<Teleportable>().ToList();
        }

        private void FixedUpdate()
        {
            foreach (var teleportable in teleportables)
            {
                if (teleportable.Enable && teleportable.transform.position.x < posA.position.x)
                    teleportable.transform.position = new Vector3(posB.position.x,teleportable.transform.position.y,
                        teleportable.transform.position.z);
            
                if (teleportable.Enable && teleportable.transform.position.x > posB.position.x)
                    teleportable.transform.position = new Vector3(posA.position.x,teleportable.transform.position.y,
                        teleportable.transform.position.z);
            }
        }
    }

    
}