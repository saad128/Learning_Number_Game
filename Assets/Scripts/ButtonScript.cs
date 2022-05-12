using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonScript : MonoBehaviour
{
    private GameObject panelObject;
    [SerializeField] private GameObject spawnManager;

    private void Start()
    {
        panelObject = GetComponentInParent<RectTransform>().parent.gameObject;
    }
    public void ButtonMethod(Button button)
    {

        GameManager.instance.SetNumber(button.GetComponentInChildren<TextMeshProUGUI>().text);
        //Debug.Log(button.name);
        panelObject.SetActive(false);
        GameManager.instance.StartGame(0);
    }
}
