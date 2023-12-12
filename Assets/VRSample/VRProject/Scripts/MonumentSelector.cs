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
    private TextMeshPro text;
    #endregion

    #region Unity Methods
    private void Start()
    {
        afterMonument.SetActive(false);
        isAfterActive = true;
        text = buttontext.GetComponent<TextMeshPro>();
    }
    #endregion

    public void SwitchMonument()
    {
        if (isAfterActive)
        {
            Debug.Log("click");
            afterMonument.SetActive(true);
            previousMonument.SetActive(false);
            isAfterActive = false;
            text.text = "Abans";
        }
        else
        {
            afterMonument.SetActive(false);
            previousMonument.SetActive(true);
            isAfterActive = true;
            text.text = "Després";
        }
    }
}