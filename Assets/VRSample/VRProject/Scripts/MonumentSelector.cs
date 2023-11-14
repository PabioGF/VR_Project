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
        AfterOff = false;
        PrevOff = false;
    }

    public void TurnOffAfter()
    {
        if (!AfterOff)
        {
            AfterMonument.SetActive(false);
            AfterOff = true;
        }
        else
        {
            AfterMonument.SetActive(true);
            AfterOff = false;
        }

    }
    public void TurnOffPrevious()
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

    }
}