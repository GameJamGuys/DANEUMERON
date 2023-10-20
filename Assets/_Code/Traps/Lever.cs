using System;
using _Code.Components;
using UnityEngine;

namespace _Code.Traps
{
    [RequireComponent(typeof(ExitTriggerComponent))]
    [RequireComponent(typeof(EnterTriggerComponent))]
    public class Lever : MonoBehaviour
    {
        [SerializeField] private string touchingTag = "Player";
        [SerializeField] private InteractionObject objectToInteraction;
        [SerializeField] private Animator anim;

        private ExitTriggerComponent _exitTriggerComponent;
        private EnterTriggerComponent _enterTriggerComponent;
        private bool _isTrigger;
        private bool _isUp;

        private void Awake()
        {
            _exitTriggerComponent = GetComponent<ExitTriggerComponent>();
            _enterTriggerComponent = GetComponent<EnterTriggerComponent>();

            //Настройка компонента Enter Trigger
            _enterTriggerComponent.Tag = touchingTag;
            _enterTriggerComponent.Action.AddListener(OnIsTrigger);

            //Настройка компонента Exit Trigger
            _exitTriggerComponent.Tag = touchingTag;
            _exitTriggerComponent.Action.AddListener(OffIsTrigger);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _isTrigger)
            {
                objectToInteraction.Interact();
                Interact();
            }
        }

        //Если нажали на рычаг в области триггера
        private void Interact()
        {
            if (!_isUp)
            {
                _isUp = true;
                if (anim != null) anim.Play("Up");
            }
            else
            {
                _isUp = false;
                if (anim != null) anim.Play("Down");
            }
        }

        private void OnIsTrigger(GameObject gb)
        {
            _isTrigger = true;
        }

        private void OffIsTrigger(GameObject gb)
        {
            _isTrigger = false;
        }
    }
}