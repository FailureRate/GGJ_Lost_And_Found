using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Door : MonoBehaviour
{
    private Vector3 Slide = new Vector3(0, 10.0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        gameObject.transform.position += Slide;
    }
}
