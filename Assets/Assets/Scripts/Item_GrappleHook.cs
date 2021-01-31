using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_GrappleHook : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] GameObject HidingHole;
    [SerializeField] float distanceToPlayer;
    [SerializeField] private Transform playerHullTransform;
    public GameObject hook;
    public float hookTravelSpeed;
    public float playerTravelSpeed;
    public static bool fired;
    public bool hooked;
    public float maxDistance;
    private float currentDistance;
    public Vector3 hookposition;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && fired == false)
            fired = true;
       
        if(fired == true && hooked == false)
        {
            hook.transform.Translate(playerHullTransform.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }
                
                
        }

        
        if (hooked == true )
        {
            
            Vector3 something = hook.transform.position - transform.position;
            something.Normalize();

            controller.Move(something * Time.deltaTime * playerTravelSpeed);
            hookposition = hook.transform.position;

            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);
            Debug.Log(distanceToHook);
           

            if (distanceToHook < distanceToPlayer)
            {
                ReturnHook();
                
            }
                
            
        }
        if (fired == false && hooked == false)
        {
            hook.transform.position = HidingHole.transform.position;
        }

    }

    public void SetHookState(bool state_)
    {
        hooked = state_;
    }

    void ReturnHook()
    {

        GameObject.Find("PlayerHolder").GetComponent<PL_Movement>().canMove = true;
        fired = false;
        hooked = false;
        Debug.Log("test");
    }
}
