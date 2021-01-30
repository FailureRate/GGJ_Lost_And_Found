using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_GrappleHook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Transform objectHit = hit.transform;

                Debug.DrawRay(transform.position, hit.point, Color.green);
                Debug.Log("hit");

            }
           /* else
            {
                Debug.Log("didnt hit");
            } */
        }
    }
}
