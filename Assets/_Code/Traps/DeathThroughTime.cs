using _Code.Components;
using _Code.Utils;
using UnityEngine;

namespace _Code.Traps
{
    [RequireComponent(typeof(StayTriggerComponent))]
    [RequireComponent(typeof(EnterTriggerComponent))]
    public class DeathThroughTime : MonoBehaviour
    {
        [SerializeField] private float timeInSeconds = 5;
        [SerializeField] private string touchingTag = "Player";
        
        private Cooldown _cooldown;
        private bool _isWorked;
        private StayTriggerComponent _stayTriggerComponent;
        private EnterTriggerComponent _enterTriggerComponent;
        
        private void Awake()
        {
            _stayTriggerComponent = GetComponent<StayTriggerComponent>();
            _enterTriggerComponent = GetComponent<EnterTriggerComponent>();
            
            //Настройка компонента Stay Trigger
            _stayTriggerComponent.Tag = touchingTag;
            _stayTriggerComponent.ActionStay.AddListener(DeadAfterTime);
            
            //Настройка компонента Enter Trigger
            _enterTriggerComponent.Tag = touchingTag;
            _enterTriggerComponent.Action.AddListener(ResetCooldown);

            //Настройка кулдауна
            _cooldown = new Cooldown(timeInSeconds);
        }
        
        //Метод, вызываемый при смерти объекта при взаимодействии за время timeInSeconds
        private void DeadAfterTime(GameObject dyingObject)
        {
            if (_cooldown.IsReady && !_isWorked)
            {
                if (dyingObject != null)
                {
                    dyingObject.GetComponent<DeadComponent>().Dead();
                    _isWorked = true;
                }
                
                _cooldown.Reset();
            }
        }

        //Сброс кулдауна
        private void ResetCooldown(GameObject gb)
        {
            _cooldown.Reset();
        }
    }
}