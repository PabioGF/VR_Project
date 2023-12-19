using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonumentSelector : MonoBehaviour
{
    #region Global Variables
    [SerializeField] private GameObject afterMonument;
    [SerializeField] private GameObject previousMonument;
    [SerializeField] private GameObject buttontext;

    private bool isAfterActive;
    private TextMeshProUGUI text;
    #endregion

    #region Unity Methods
    private void Start()
    {
        afterMonument.SetActive(false);
        isAfterActive = false;
        text = buttontext.GetComponent<TextMeshProUGUI>();
    }
    #endregion

    public void SwitchMonument()
    {
        Debug.Log("Clicl");
        if (!isAfterActive)
        {
            afterMonument.SetActive(true);
            previousMonument.SetActive(false);
            isAfterActive = true;
            text.text = "Abans";
        }
        else
        {
            afterMonument.SetActive(false);
            previousMonument.SetActive(true);
            isAfterActive = false;
            text.text = "Després";
        }
    }
}