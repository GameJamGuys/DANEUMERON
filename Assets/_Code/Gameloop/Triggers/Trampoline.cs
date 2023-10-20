using System;
using TarodevController;
using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] float scale = 2;
        [SerializeField] private float minForce = 1;
        [SerializeField] private float maxForce = 3;

        private float _lastVelocity;
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<Rigidbody2D>(out var rb))
            {
                
                if (col.gameObject.TryGetComponent<PlayerController>(out var playerController))
                {
                    playerController.TrampolineJump(_lastVelocity*2);
                }
                else
                {
                    // Debug.Log(-rb.velocity);
                    rb.velocity = new Vector2(rb.velocity.x, _lastVelocity);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Rigidbody2D>(out var rb))
            {
                _lastVelocity = -rb.velocity.y;
                _lastVelocity = Mathf.Clamp(_lastVelocity, minForce, maxForce);
                _lastVelocity *= scale;
                // Debug.Log(_lastVelocity);
            }
        }
    }
}