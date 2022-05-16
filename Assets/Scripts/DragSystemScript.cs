using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragSystemScript : MonoBehaviour
{

    private GameObject correctForm;
    private bool isDragging, finished = false;
    private float startPosX, startPosY;
    private Vector3 resetPosition;

    

    private void Start()
    {
        resetPosition = this.transform.localPosition;
        correctForm = gameObject;

    }

    private void Update()
    {
        if (finished == false)
        {
            if (isDragging)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.transform.localPosition.z);
            }
        }

    }

    private void OnMouseDown()
    {
       


            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isDragging = true;
        
    }



    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");

        isDragging = false;
        if (Mathf.Abs(this.transform.position.x - correctForm.transform.position.x) < 2f &&
            Mathf.Abs(this.transform.position.y - correctForm.transform.position.y) < 2f)
        {
            Debug.Log(correctForm.name);
            this.transform.position = new Vector3(correctForm.transform.position.x,
                correctForm.transform.position.y, correctForm.transform.position.z);
            finished = true;
            Debug.Log("before Counter start");
            GameManager.instance.counter++;
            Destroy(correctForm.gameObject);
            Debug.Log("after Counter start");

            if (GameManager.instance.counter == 3)
            {
                
                GameManager.instance.StartGame(2);
                
            }
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }

    }

    


}
