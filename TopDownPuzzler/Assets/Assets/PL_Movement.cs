using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Movement : MonoBehaviour
{
    [Header("Reffrences")] 
    [SerializeField] private CharacterController controller;

    [Header("Movement Generics")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 movementVector;
 
    // Start is called before the first frame update
    void Start()
    {
        if (!controller)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementVector = (transform.right * x) + (transform.forward * z);

        controller.Move(movementVector * movementSpeed * Time.deltaTime);
    }
}
