using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColorPrefabs : MonoBehaviour
{

    [SerializeField] private List<GameObject> spawnColorPrefabs;
    [SerializeField] private int indexOfColorPrefab;
    [SerializeField] private Collider2D[] colliders;
    [SerializeField] private float radius;

    

   

    void Start()
    {
        FindingIndexofPrefab();
        SpawnSelectedPrefab();
    }

    void FindingIndexofPrefab()
    {
        foreach (var item in spawnColorPrefabs)
        {
            if (item.name.Contains(GameManager.instance.GetNumber()))
            {
                indexOfColorPrefab = spawnColorPrefabs.IndexOf(item);
            }
        }
    }

    bool PreventSpawnOverlap(Vector2 spawnPos)
    {
        Debug.Log("enter the preventspawn overlap");
        colliders = Physics2D.OverlapBoxAll(transform.localPosition, transform.localScale, 0f);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector2 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtents = centerPoint.x - width;
            float rightExtents = centerPoint.x + width;
            float lowerExtents = centerPoint.y - height;
            float upperExtents = centerPoint.y + height;

            if (spawnPos.x >= leftExtents && spawnPos.x <= rightExtents)
            {
                if (spawnPos.y >= lowerExtents && spawnPos.y <= upperExtents)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void SpawnSelectedPrefab()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 spawnPos = new Vector2(0, 0);
            bool canSpawnHere = false;
            int safetyNet = 0;


            while (!canSpawnHere)
            {
                float spawnPosX = Random.Range(-10, 10);
                float spawnPosY = 2f;
                spawnPos = new Vector2(spawnPosX, -spawnPosY);
                canSpawnHere = PreventSpawnOverlap(spawnPos);

                if (canSpawnHere)
                {
                    break;
                }

                safetyNet++;
                if (safetyNet > 50)
                {
                    Debug.Log("Too many attempt");
                    break;
                }
            }
            Instantiate(spawnColorPrefabs[indexOfColorPrefab], spawnPos, Quaternion.identity);
        }
    }

}
