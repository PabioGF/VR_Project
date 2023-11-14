using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentSelector : MonoBehaviour
{
    public GameObject AfterMonument;
    public GameObject PreviousMonument;
    bool AfterOff;
    bool PrevOff;
    private void Start()
    {
        AfterMonument.SetActive(false);
        AfterOff = true;
        PrevOff = false;
    }

    public void TurnOffAfter()
    {
        if (AfterOff)
        {
            AfterMonument.SetActive(true);
            PreviousMonument.SetActive(false);
            AfterOff = false;
            
        }
        else
        {
            AfterMonument.SetActive(false);
            PreviousMonument.SetActive(true);
            AfterOff = true;
        }

    }
    /**public void TurnOffPrevious()
    {

        if (!PrevOff)
        {
            PreviousMonument.SetActive(false);
            PrevOff = true;
        }
        else
        {
            PreviousMonument.SetActive(true);
            PrevOff = false;
        }

    }**/
}