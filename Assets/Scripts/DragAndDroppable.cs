using System;
using UnityEngine;

public class DragAndDroppable : MonoBehaviour
{
    [SerializeField] private GameObject cover;
    [SerializeField] private SpriteRenderer side;
    [SerializeField] private GameObject otherSideStuff;
    [SerializeField] private BoxCollider2D collider;

    private GameObject cursor;
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    private bool isSideways = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        bc = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        transform.SetParent(cursor.transform);
        bc.enabled = false;
        rb.simulated = false;
        RotateBook();
    }

    private void OnMouseUp()
    {
        transform.SetParent(null);
        bc.enabled = true;
        rb.simulated = true;
        RotateBook();
    }

    private void RotateBook()
    {
        isSideways = !isSideways;
        cover.SetActive(!isSideways);
        otherSideStuff.SetActive(isSideways);
        side.enabled = isSideways;
        collider.enabled = isSideways;
    }
}
