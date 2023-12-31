﻿using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

namespace _Code.Gameloop.Pickup
{
    public class PickUpHandler : MonoBehaviour
    {
        [SerializeField] private Transform pickUpTransform;
        [SerializeField][Range(0.1f,1)] private float pickUpDistance =.5f;
        [SerializeField] private float distanceDetection = 1f;
        [SerializeField] private SpriteRenderer flipRenderer;
        [SerializeField] private Vector2 dropForce = new Vector2(25000,25000);
        [SerializeField] private GameObject eButton;
        private bool _interactionEnable;
        
        private PickupObject _currentPickUpObject;
        private PickupObject _currentDetectionObject;
        
        public int Direction => flipRenderer.flipX ? -1 : 1;
        
        
        private void FixedUpdate()
        {
            // if (_interactionEnable)
                CheckPickup();
        }

        void CheckPickup()
        {
            pickUpTransform.localPosition = new Vector3(pickUpDistance * Direction, pickUpTransform.localPosition.y, pickUpTransform.localPosition.z);
            RaycastHit2D hit = Physics2D.Raycast(pickUpTransform.position, transform.right * Direction, distanceDetection);

            if (hit.collider != null)
            {
                if (hit.transform.TryGetComponent<PickupObject>(out var pickupObject))
                {
                    SetEButton(true);
                    _currentDetectionObject = pickupObject;
                }
                else
                {
                    
                    SetEButton(false);
                    _currentDetectionObject = null;
                }
            }
            else
            {
                SetEButton(false);
                _currentDetectionObject = null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pickUpTransform.position, pickUpTransform.position + 
                                                      pickUpTransform.right * Direction
                                                                            * distanceDetection);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (_currentPickUpObject == null)
                    PickUp();
                else
                    Drop();
            }
        }

        public void SetEButton(bool enable)
        {
            eButton.SetActive(enable);
        }

        public void PickUp()
        {
            if (_currentDetectionObject == null)
                return;
            _currentPickUpObject = _currentDetectionObject;
            _currentPickUpObject.Select();
            _currentPickUpObject.transform.parent = pickUpTransform;
            _currentDetectionObject.transform.localPosition = Vector3.zero;
            _currentDetectionObject.transform.localEulerAngles= Vector3.zero;
        }

        void Drop()
        {
            if (_currentPickUpObject == null)
                return;
            _currentPickUpObject.transform.parent = null;
            _currentPickUpObject.UnSelect(new Vector2(dropForce.x * Direction, dropForce.y));
            _currentPickUpObject = null;
        }
    }
}