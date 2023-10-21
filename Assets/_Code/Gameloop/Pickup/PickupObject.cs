using System;
using System.Collections;
using _Code.Gameloop.Triggers;
using TarodevController;
using UnityEngine;

namespace _Code.Gameloop.Pickup
{
    public class PickupObject : Teleportable
    {
        [SerializeField] float breakVelocity;
        [SerializeField] float deadVelocity = 15f;
        [SerializeField] private GameObject deadTrigger;

        private bool _break;
        private Collider2D _collider;
        private Rigidbody2D _rb;
        private bool _picked;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Select()
        {
            _enable = false;
            _rb.isKinematic = true;
            _collider.enabled = false;
        }

        public void UnSelect(Vector2 force)
        {
            _enable = true;
            _rb.isKinematic = false;
            _rb.AddForce(force);
            StartCoroutine(WaitAndEnableCollider(.01f));
        }

        IEnumerator WaitAndEnableCollider(float time)
        {
            yield return new WaitForSeconds(time);
            _collider.enabled = true;
        }
        
        private void FixedUpdate()
        {
            _break = _rb.velocity.magnitude > breakVelocity;
            deadTrigger.SetActive(_rb.velocity.magnitude > deadVelocity);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (_break && col.transform.TryGetComponent<BreakableObject>(out var breakableObject))
            {
                breakableObject.Broke();
            }
        }
    }
}