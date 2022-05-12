using System.Collections;
using System.Collections.Generic;
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
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mousePos = (Input.mousePosition);
        //    Vector2 mouseInitialPosition = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);
        //    Offset = mouseInitialPosition - (Vector2)transform.position;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    mousePos = (Input.mousePosition);
        //    Vector2 targetPos = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);

        //    targetPos.x = Mathf.Clamp(targetPos.x - Offset.x, MinPos.x, MaxPos.x);
        //    targetPos.y = Mathf.Clamp(targetPos.y - Offset.y, MinPos.y, MaxPos.y);
        //    transform.Translate(targetPos);
        //}
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("BottomPoint"))
        {
           // Debug.Log("collided");
            numberObject.GetComponent<SpriteRenderer>().material.color = Color.green;
            Destroy(gameObject);
        }
    }
}
