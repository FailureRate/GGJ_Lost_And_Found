using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_FollowPlayer : MonoBehaviour
{
    [Header("Reffrences")]
    [SerializeField] private Transform playerLocation;
    [Header("Generics")]
    [SerializeField] private float cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionChange = new Vector3(playerLocation.position.x, cameraDistance, playerLocation.position.z);
        this.transform.position = positionChange;
        
    }
}
