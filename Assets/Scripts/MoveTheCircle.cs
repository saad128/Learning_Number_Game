using UnityEngine;

public class MoveTheCircle : MonoBehaviour
{
    private GameObject numberObject;
   
    bool isDragging = false;

    private void Start()
    {
        numberObject = transform.parent.gameObject;
       
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided");
        if (collision.gameObject.CompareTag("BottomPoint"))
        {
            // Debug.Log("collided");
            numberObject.GetComponent<SpriteRenderer>().material.color = Color.green;
            //if() { }
            Destroy(gameObject);
        }
    }
}
