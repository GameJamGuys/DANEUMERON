using System;
using UnityEngine;

namespace _Code
{
    public class CatEyeTracking : MonoBehaviour
    {
        [SerializeField] private GameObject objectForTracking;
        [Range(0f, 1f)] [SerializeField] private float trackingForce = 1;
        [Min(0f)] [SerializeField] private float boundingRadius = 1;
        [SerializeField] private bool isMouseTracking;

        [Header("Debug Settings")] [SerializeField]
        private bool showRadius = true;

        private Vector3 _startPosition;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            boundingRadius = boundingRadius * transform.localScale.x;

            if (transform.parent != null)
                _startPosition = transform.localPosition;
            else
                _startPosition = transform.position;
        }

        private void Update()
        {
            Vector2 toTarget;
            var mouseForTracking = _camera.ScreenToWorldPoint(Input.mousePosition);


            if (transform.parent != null)
            {
                if (isMouseTracking)
                {
                    toTarget = transform.parent.InverseTransformPoint(
                        mouseForTracking) - _startPosition;
                }
                else
                {
                    toTarget = transform.parent.InverseTransformPoint(objectForTracking.transform.position) -
                               _startPosition;
                }

                transform.localPosition = NewPosition(toTarget);

            }
            else
            {
                if (isMouseTracking)
                {
                    toTarget = mouseForTracking - _startPosition;
                }
                else
                {
                    toTarget = objectForTracking.transform.position - _startPosition;
                }

                transform.position = NewPosition(toTarget);
                
            }
        }

        private Vector2 NewPosition(Vector2 target)
        {
            return (Vector2)_startPosition + Vector2.ClampMagnitude(target * trackingForce, boundingRadius);
        }

        private void OnDrawGizmos()
        {
            if (showRadius == false) return;

            if (Application.isPlaying)
            {
                if (transform.parent != null)
                    Gizmos.DrawWireSphere(transform.parent.TransformPoint(_startPosition), boundingRadius);
                else
                    Gizmos.DrawWireSphere(_startPosition, boundingRadius);
            }
            else
            {
                Gizmos.DrawWireSphere(transform.position, boundingRadius);
            }
        }
    }
}