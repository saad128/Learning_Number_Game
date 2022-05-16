using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlackPrefabs : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnBlackPrefabs;
    [SerializeField] private int indexofBlackPrefab;

    private void Start()
    {
        FindingtheIndexofBlackPrefab();
        SpawnSelectedPrefabs();
    }

    void FindingtheIndexofBlackPrefab()
    {
        foreach (var item in spawnBlackPrefabs)
        {
            if (item.name.Contains(GameManager.instance.GetNumber()))
            {
                indexofBlackPrefab = spawnBlackPrefabs.IndexOf(item);
            }
        }
    }

    void SpawnSelectedPrefabs()
    {
        for (int i = 0; i < 3; i++)
        {
            var Position = new Vector2(Random.Range(-10, 10), 2);
            Instantiate(spawnBlackPrefabs[indexofBlackPrefab], Position, Quaternion.identity);
            
        }
    }


   
}
