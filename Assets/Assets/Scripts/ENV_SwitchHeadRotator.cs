using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_SwitchHeadRotator : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] Transform objectRef;
    [Header("Generics")]
    [SerializeField] float rotateSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        objectRef.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
