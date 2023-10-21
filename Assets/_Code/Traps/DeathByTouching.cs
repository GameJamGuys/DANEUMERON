using System;
using _Code.Components;
using UnityEngine;

namespace _Code.Traps
{
    [RequireComponent(typeof(EnterTriggerComponent))]
    public class DeathByTouching : MonoBehaviour
    {
        [SerializeField] private string touchingTag = "Player";
        
        private EnterTriggerComponent _enterTriggerComponent;
        
        private void Awake()
        {
            _enterTriggerComponent = GetComponent<EnterTriggerComponent>();
            
            //Настройка компонента Enter Trigger
            _enterTriggerComponent.Tag = touchingTag;
            _enterTriggerComponent.Action.AddListener(Dead);
        }

        
        //Метод, вызываемый при смерти объекта, до которого дотронулись
        public void Dead(GameObject dyingObject)
        {
            if (dyingObject != null)
            {
                dyingObject.GetComponent<DeadComponent>().Dead();
            }
        }
    }
}