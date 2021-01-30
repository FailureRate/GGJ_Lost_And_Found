using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Door : MonoBehaviour
{
    private Vector3 Slide = new Vector3(0, 7.58f, 0);

    public void Activate()
    {
        gameObject.transform.position -= Slide;
    }

    public void Deactivate()
    {
        gameObject.transform.position += Slide;
    }
}