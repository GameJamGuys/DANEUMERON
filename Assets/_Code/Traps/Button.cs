using _Code.Components;
using UnityEngine;

namespace _Code.Traps
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private InteractionObject objectToInteraction;
        [SerializeField] private Animator anim;

        private bool _isTwo;
        private bool _isSecondInteraction;
        private bool _isLoop = true;

        public bool IsSecondInteraction
        {
            get => _isSecondInteraction;
            set => _isSecondInteraction = value;
        }

        public bool IsTwo
        {
            get => _isTwo;
            set => _isTwo = value;
        }

        public bool IsLoop
        {
            get => _isLoop;
            set => _isLoop = value;
        }

        private void Select()
        {
            anim.Play("Down");

            if (objectToInteraction != null)
                if (_isSecondInteraction)
                {
                    objectToInteraction.SecondInteract();
                }
                else
                {
                    objectToInteraction.Interact();
                }
        }

        private void Deselect()
        {
            anim.Play("Up");

            if (_isTwo)
            {
                objectToInteraction.ThirdInteract();
            }
            
            if (_isLoop)
            {
                if (objectToInteraction != null)
                    objectToInteraction.Interact();
            }
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