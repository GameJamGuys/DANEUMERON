using System;
using Audio;
using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class WaterTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Rigidbody2D>())
                AudioBox.Instance.Play("Water");
        }
    }
}