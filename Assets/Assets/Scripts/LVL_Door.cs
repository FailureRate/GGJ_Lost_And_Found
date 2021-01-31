using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Door : MonoBehaviour
{
    private Vector3 Slide = new Vector3(0, 7.58f, 0);
    public bool isOpen;

    public void Activate()
    {
        if (isOpen == false)
        {
            gameObject.transform.position -= Slide;
            isOpen = true;
        }
    }

    public void Deactivate()
    {
        if (isOpen == true)
        {
            gameObject.transform.position += Slide;
            isOpen = false;
        }
    }
}