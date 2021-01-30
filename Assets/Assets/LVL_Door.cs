using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Door : MonoBehaviour
{
    private Vector3 Slide = new Vector3(0, 10.0f, 0);
    void Start()
    {
    }

    void Update()
    {
    }

    public void Activate()
    {
        gameObject.transform.position += Slide;
    }
}