using _Code.Components;
using UnityEngine;

namespace _Code.Traps
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private InteractionObject objectToInteraction;
        [SerializeField] private Animator anim;

        private void Select()
        {
            anim.Play("Up");
            objectToInteraction.Interact();
        }

        private void Deselect()
        {
            anim.Play("Down");
            objectToInteraction.Interact();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ButtonPresser buttonPresser))
            {
                Select();
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out ButtonPresser buttonPresser))
            {
                Deselect();
            }
        }
    }
}