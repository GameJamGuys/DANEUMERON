using UnityEngine;
using UnityEngine.Events;

namespace _Code.Traps
{
    public class InteractionObject : MonoBehaviour
    {
        [SerializeField] private UnityEvent interactAction;
        [SerializeField] private UnityEvent secondInteractionAction;
        [SerializeField] private UnityEvent thirdInteractionAction;
        

        public UnityEvent SecondInteractionAction
        {
            get => secondInteractionAction;
            set => secondInteractionAction = value;
        }

        public void Interact()
        {
            interactAction?.Invoke();
        }

        public void SecondInteract()
        {
            secondInteractionAction?.Invoke();
        }

        public void ThirdInteract()
        {
            thirdInteractionAction?.Invoke();
        }
    }
}