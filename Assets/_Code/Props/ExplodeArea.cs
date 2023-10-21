using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    public class ExplodeArea : MonoBehaviour
    {
        [SerializeField]
        float blowForce;

        List<Rigidbody2D> bodies;

        [SerializeField]
        LayerMask saveLayer;

        private void Start()
        {
            bodies = new List<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Rigidbody2D body))
            {
                if (bodies.Contains(body)) return;
                else bodies.Add(body);

                Vector3 dir = body.position - (Vector2)transform.position;
                //print($"body {body.name} dir {dir}");
                body.AddForce(dir * blowForce, ForceMode2D.Impulse);

                if (collision.TryGetComponent(out DeadComponent player))
                {
                    RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, saveLayer);
                    if (!hit) player.Dead();
                }
            }


        }
    }

}
