using System;
using Audio;
using TarodevController;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.Gameloop.Triggers
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] float scale = 2;
        [SerializeField] private float minForce = 1;
        [SerializeField] private float maxForce = 3;
        

        private Vector2 _lastVelocity;
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<Rigidbody2D>(out var rb))
            {
                string[] sounds = new[] { "Tramp1", "Tramp2", "Tramp3" };
                string sound = sounds[Random.Range(0, sounds.Length)];
                AudioBox.Instance.Play(sound );
                if (col.gameObject.TryGetComponent<PlayerController>(out var playerController))
                {
                    playerController.TrampolineJump(new Vector2(_lastVelocity.x,_lastVelocity.y*2) * transform.up);
                }
                else
                {
                    // Debug.Log(-rb.velocity);
                    rb.velocity = new Vector2(_lastVelocity.x,_lastVelocity.y) * transform.up;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Rigidbody2D>(out var rb))
            {
                _lastVelocity = -rb.velocity;
                var x = Mathf.Clamp(_lastVelocity.x, minForce, maxForce);
                var y = Mathf.Clamp(_lastVelocity.x, minForce, maxForce);
                _lastVelocity = new Vector2(x,y);
                _lastVelocity *= scale;
                // Debug.Log(_lastVelocity);
            }
        }
    }
}