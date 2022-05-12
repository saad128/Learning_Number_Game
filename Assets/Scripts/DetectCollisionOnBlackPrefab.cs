using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionOnBlackPrefab : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter the collider body");
        if (collision.gameObject.CompareTag("ColorPrefabs"))
        {
            Debug.Log("collided 5");
            Destroy(gameObject);
        }
    }
}
