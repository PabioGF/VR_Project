using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{
    public string dayScene;
    public string nightScene;
    

    public void SeleccionarEscenaDia()
    {
        SceneManager.LoadScene(dayScene);
    }

    public void SeleccionarEscenaNoche()
    {
        SceneManager.LoadScene(nightScene);
    }
}
