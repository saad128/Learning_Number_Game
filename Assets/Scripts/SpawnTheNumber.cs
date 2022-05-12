using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTheNumber : MonoBehaviour
{
    public static SpawnTheNumber instance;

    [SerializeField] private List<GameObject> numberPrefabs;
    [SerializeField] private List<GameObject> numberOfObjects;
    //[SerializeField] public int selectNumber;
    [SerializeField] private int indexOfNumber;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
   
    private void Start()
    {
        SpawnPrefabs();
        FindingIndex();
        SpawnSelectedPrefabs();
    }


    void SpawnPrefabs()
    {
        for (int i = 0; i < numberPrefabs.Count; i++)
        {
            var position = new Vector2(Random.Range(-10, 10), Random.Range(-3, 3));
            GameObject numberOfObject = Instantiate(numberPrefabs[i], position, transform.rotation);
            numberOfObjects.Add(numberOfObject);
            
           
        }
    }
    
    public void DestroytheList()
    {
        if (numberOfObjects != null)
        {
            foreach (var item in numberOfObjects)
            {

                Destroy(item);
            }
        }
    }

    void FindingIndex()
    {
        foreach (var item in numberPrefabs)
        {
            if (item.name == GameManager.instance.GetNumber())
            {
                indexOfNumber = numberPrefabs.IndexOf(item);
            }
        }
        //Debug.Log("Index" + indexOfNumber);
        //Debug.Log(numberPrefabs[indexOfNumber].name);
    }

    void SpawnSelectedPrefabs()
    {
        for (int i = 0; i < 4; i++)
        {
            var position = new Vector2(Random.Range(-10, 10), Random.Range(-3, 3));
            Instantiate(numberPrefabs[indexOfNumber], position, Quaternion.identity);
        }
    }
}


