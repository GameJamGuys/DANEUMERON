using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Code.Components
{
    public class StayTriggerComponent : MonoBehaviour
    {
        [SerializeField] private new string tag;
        [SerializeField] private GameObjectChange actionStay;

        public string Tag
        {
            get => tag;
            set => tag = value;
        }

        public GameObjectChange ActionStay
        {
            get => actionStay;
            set => actionStay = value;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(tag))
            {
                actionStay?.Invoke(other.gameObject);
            }
        }

        [Serializable]
        public class GameObjectChange : UnityEvent<GameObject>
        {
        }
    }
}