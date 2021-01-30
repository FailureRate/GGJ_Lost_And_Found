using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_SwitchActivation : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Switch");
        }
    }
}
