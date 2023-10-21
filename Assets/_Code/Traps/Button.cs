using System.Collections.Generic;
using _Code.Components;
using Audio;
using UnityEngine;

namespace _Code.Traps
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private List<InteractionObject> objectsToInteraction;
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
            AudioBox.Instance.Play("Btn");
            anim.Play("Down");

            foreach (var obj in objectsToInteraction)
            {
                if (obj != null)
                    if (_isSecondInteraction)
                    {
                        obj.SecondInteract();
                    }
                    else
                    {
                        obj.Interact();
                    }
            }
        }

        private void Deselect()
        {
            anim.Play("Up");

            if (_isTwo)
            {
                foreach (var obj in objectsToInteraction)
                {
                    obj.ThirdInteract();
                }
            }

            if (_isLoop)
            {
                foreach (var obj in objectsToInteraction)
                {
                    if (obj != null)
                        obj.Interact();
                }
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