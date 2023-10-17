using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleClick : MonoBehaviour
{

    public void ClickAction()
    {
        DoRotation();
    }

    public void HoverAction()
    {
        transform.localScale = Vector3.one * 0.25f;
    }

    public void ExitAction()
    {
        transform.localScale = Vector3.one * 0.2f;
    }


    #region Rotate
    private Coroutine rotateCo = null;

    private void DoRotation()
    {
        if (rotateCo == null)
        {
            StartCoroutine(RotateCo());
        }
    }

    #endregion

    private IEnumerator RotateCo()
    {     
        float angle = 0;
        float rotateSpeed = 60;

        while (angle < 360)
        {
            angle += Time.deltaTime * 360;
            transform.localEulerAngles = Vector3.up * angle;
            yield return null;
        }

        transform.localEulerAngles = Vector3.zero;
        rotateCo = null;
    }

}
