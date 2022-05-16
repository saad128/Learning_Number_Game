using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningtheDragtoFillColor : MonoBehaviour
{
    [SerializeField] private List<GameObject> numberObject;
    [SerializeField] private int indexOfSelectedNumber;

    private void Start()
    {
        FindingIndexofSelectedNumber();
        SpawntheSelectedNumber();
    }
    void FindingIndexofSelectedNumber()
    {
        foreach (var item in numberObject)
        {
            if (item.name.Contains(GameManager.instance.GetNumber()))
            {

                indexOfSelectedNumber = numberObject.IndexOf(item);
            }
        }

        Type type = numberObject[indexOfSelectedNumber].GetType();
    }

    void SpawntheSelectedNumber()
    {
        Instantiate(numberObject[indexOfSelectedNumber], new Vector2(0f, 0f), Quaternion.identity);
    }
}
