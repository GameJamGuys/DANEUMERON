using UnityEngine;

public class ResizeLogic : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    BoxCollider2D box;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        SetBox();
    }

    public void SetBox() => box.size = sprite.size;
}