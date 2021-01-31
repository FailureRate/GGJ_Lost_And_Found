using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_ObjectRotator : MonoBehaviour
{
    [Header("Refrence")]
    [Tooltip("The Object to rotate")]
    [SerializeField] private Transform objectRef;

    [Header("Axis to Rotate")]
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;

    [Header("Rotation Speed")]
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates on the X Y or Z axis depeding on what was checked
        if(x)
            objectRef.Rotate(rotationSpeed * Time.deltaTime ,0,0);
        if (y)
            objectRef.Rotate(0,rotationSpeed * Time.deltaTime, 0 );
        if (z)
             objectRef.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
