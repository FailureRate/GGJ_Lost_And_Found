using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Movement : MonoBehaviour
{
    [Header("Reffrences")] 
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject playerModel;

    [Header("Movement Generics")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private Vector3 pointToLook;
    [SerializeField] private Vector3 yVelocity;
    [SerializeField] private float gravity;
    [SerializeField] public bool canMove;


    // Start is called before the first frame update
    void Start()
    {
        if (!controller)
        {
            controller = GetComponent<CharacterController>();
            Debug.Log("Character Controller not found adding from script");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            // Gets X and Z axis changes
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            // Gravity
            yVelocity.y += gravity * Time.deltaTime;
            // Makes sure to building up downward velocity
            if (controller.isGrounded && yVelocity.y < -2.0f) yVelocity.y = -2.0f;
            // Adds the X and Z axis changes to a vector
            movementVector = (transform.right * x) + (transform.forward * z);
            // Moves the player
            controller.Move(movementVector * movementSpeed * Time.deltaTime);
            controller.Move(yVelocity * Time.deltaTime);
            rotateModelAt();
        }
        if (Input.GetMouseButtonDown(1) && GameManager.playerHasBomb)
        {
            canMove = false;
            StartCoroutine(waiter());
        }
    }

    private void rotateModelAt()
    {
        // Gets the point from camera from ray 
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        // plane to work with to get the xyz cordinates
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        
        float rayLength;
        // Ray casts the intercesion of ray to plane and gets ray legnth
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            // gets the point on the invisible plane
            pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);
            // Rotates the player to the xz cordinates
            playerModel.transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

    }

    IEnumerator waiter()
    {
        yield return new WaitUntil(() =>canMove);

    }
}
