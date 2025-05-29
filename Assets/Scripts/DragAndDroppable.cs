using UnityEngine;

public class DragAndDroppable : MonoBehaviour
{
    public GameObject cursor;
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        bc = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.SetParent(cursor.transform);
        bc.enabled = false;
        rb.simulated = false;
    }

    private void OnMouseUp()
    {
        transform.SetParent(null);
        bc.enabled = true;
        rb.simulated = true;
    }
}
