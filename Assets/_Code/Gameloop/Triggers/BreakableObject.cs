using UnityEngine;

namespace _Code.Gameloop.Triggers
{
    public class BreakableObject : MonoBehaviour
    {
        public void Broke()
        {
            Destroy(gameObject);
        }
    }
}