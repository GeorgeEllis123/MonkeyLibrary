using UnityEngine;

public class CursorController : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 1f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
