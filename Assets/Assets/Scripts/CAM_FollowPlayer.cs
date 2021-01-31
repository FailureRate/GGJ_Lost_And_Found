using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_FollowPlayer : MonoBehaviour
{
    [Header("Reffrences")]
    [SerializeField] private Transform playerLocation;
    [Header("Generics")]
    [Tooltip("Smoothspeed = 1 frame")]
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offSet = new Vector3(0,25,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = playerLocation.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        this.transform.position = smoothedPosition;
        
    }
}
