using System;
using UnityEngine;
using UnityEngine.Events;

public class TAG_EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private new string tag;
    [SerializeField] private GameObjectChange action;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            action?.Invoke(other.gameObject);
        }
    }
    
    [Serializable]
    public class GameObjectChange : UnityEvent<GameObject>
    {
        
    }
}