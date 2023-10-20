using System;
using _Code.Components;
using UnityEngine;

namespace _Code.Traps
{
    [RequireComponent(typeof(EnterTriggerComponent))]
    public class DeathByTouching : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        
        private EnterTriggerComponent _enterTriggerComponent;
        private void Awake()
        {
            _enterTriggerComponent = GetComponent<EnterTriggerComponent>();
            _enterTriggerComponent.Tag = playerTag;
            _enterTriggerComponent.Action.AddListener(Dead);
        }

        public void Dead(GameObject dyingObject)
        {
            dyingObject.GetComponent<DeadComponent>().Dead();
        }
    }
}