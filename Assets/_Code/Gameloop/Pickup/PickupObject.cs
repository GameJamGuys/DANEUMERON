using System;
using System.Collections;
using UnityEngine;

namespace _Code.Gameloop.Pickup
{
    public class PickupObject : MonoBehaviour
    {
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
            _rb.isKinematic = true;
            _collider.enabled = false;
        }

        public void UnSelect(Vector2 force)
        {
            _rb.isKinematic = false;
            _rb.AddForce(force);
            StartCoroutine(WaitAndEnableCollider(.01f));
        }

        IEnumerator WaitAndEnableCollider(float time)
        {
            yield return new WaitForSeconds(time);
            _collider.enabled = true;
        }
    }
}