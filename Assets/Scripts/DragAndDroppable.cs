using System;
using UnityEngine;

public class DragAndDroppable : MonoBehaviour
{
    [SerializeField] private GameObject cover;
    [SerializeField] private SpriteRenderer side;
    [SerializeField] private GameObject otherSideStuff;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private Sprite grabImage;
    [SerializeField] private Sprite idleImage;

    private GameObject cursor;
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    private bool canBeMoved = true;
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
        if (canBeMoved)
        {
            transform.SetParent(cursor.transform);
            cursor.GetComponentInChildren<SpriteRenderer>().sprite = grabImage;
            bc.enabled = false;
            rb.simulated = false;
            RotateBook();
        }
    }

    private void OnMouseUp()
    {
        if (canBeMoved)
        {
            transform.SetParent(null);
            cursor.GetComponentInChildren<SpriteRenderer>().sprite = idleImage;
            bc.enabled = true;
            rb.simulated = true;
            RotateBook();
        }
            
    }

    private void RotateBook()
    {
        isSideways = !isSideways;
        cover.SetActive(!isSideways);
        otherSideStuff.SetActive(isSideways);
        side.enabled = isSideways;
        collider.enabled = isSideways;
    }

    public void Lock()
    {
        canBeMoved = false;
    }
}
