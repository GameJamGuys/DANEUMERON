using System;
using TarodevController;
using UnityEngine;
using UnityEngine.Events;

namespace _Code.Components
{
    public class ExitTriggerComponent : MonoBehaviour
    {
        // [SerializeField] private new string tag;
        [SerializeField] private GameObjectChange action;

        public string Tag
        {
            get => tag;
            set => tag = value;
        }

        public GameObjectChange Action
        {
            get => action;
            set => action = value;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            
            if (other.TryGetComponent<PlayerController>(out var player))
            {
                action?.Invoke(other.gameObject);
            }
        }

        [Serializable]
        public class GameObjectChange : UnityEvent<GameObject>
        {

        }
    }
}
