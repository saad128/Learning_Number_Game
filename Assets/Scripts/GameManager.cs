using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int counter;
    private string chooseLearningNumber;

    [SerializeField] List<GameObject> GameToStart;



    public void StartGame(int GameNumber)
    {
        for (int i = 0; i < GameToStart.Count; i++)
        {
            if (GameNumber == i)
            {
                GameToStart[i].SetActive(true);
            }
            else
            {
                GameToStart[i].SetActive(false);
            }
        }
    }

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

    public string GetNumber()
    {
        return chooseLearningNumber;
    }
    public void SetNumber(string chooseLearningNumber)
    {
         this.chooseLearningNumber = chooseLearningNumber;
    }

}
