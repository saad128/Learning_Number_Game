using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestoryTheNumber : MonoBehaviour
{
    //private GameObject spawnManager;
    //[SerializeField] private GameObject secondMiniGame;

    
    private void Update()
    {
        DetectGameObject();
    }


    void DetectGameObject()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.name);
                //Debug.Log("hitted object" + hit.collider.name);
                //Debug.Log("selected number" + SpawnTheNumber.instance.selectNumber);
                if (hit.collider.name.StartsWith(GameManager.instance.GetNumber()))
                {
                    //Debug.Log(hit.collider.name);
                    //Debug.Log(GameManager.instance.GetNumber());
                    Destroy(hit.collider.gameObject);
                    GameManager.instance.counter++;
                    if(GameManager.instance.counter == 5)
                    {
                        GameManager.instance.counter = 0;
                        SpawnTheNumber.instance.DestroytheList();
                        GameManager.instance.StartGame(1);
                    }
                }
            }
        }
    }
    
}
