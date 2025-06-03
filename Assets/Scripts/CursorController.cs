using UnityEngine;

public class CursorController : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 1f;

    public Sprite idleSprite;
    public Sprite clickSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Cursor.visible = false;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("ur a silly goose");
        }
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (Input.GetMouseButton(0))
        {
            spriteRenderer.sprite = clickSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
}
