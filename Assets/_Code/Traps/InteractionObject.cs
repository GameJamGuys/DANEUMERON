using UnityEngine;
using UnityEngine.Events;

namespace _Code.Traps
{
    public class InteractionObject : MonoBehaviour
    {
        [SerializeField] private UnityEvent interactAction;
        
        public void Interact()
        {
            interactAction?.Invoke();
        }
    }
}