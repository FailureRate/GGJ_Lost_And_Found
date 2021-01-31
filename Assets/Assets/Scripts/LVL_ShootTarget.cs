using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_ShootTarget : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject[] Interactable;


    [Header("Material")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material deactivatedMat;

    [Header("Reference")]
    [SerializeField] private GameObject Crystal;

    [SerializeField] private bool isSwitchActivated;
    public LVL_Door DoorScript;

    private void Update()
    {
        if (Interactable.Length > 1)
        {
            if (isSwitchActivated)
            {
                Crystal.GetComponent<MeshRenderer>().material = activatedMat;
            }
            else
            {
                Crystal.GetComponent<MeshRenderer>().material = deactivatedMat;
            }
        }
        else
        {
            if (DoorScript.isOpen == true)
            {
                Crystal.GetComponent<MeshRenderer>().material = activatedMat;
                isSwitchActivated = true;
            }

            else if (DoorScript.isOpen == false)
            {
                Crystal.GetComponent<MeshRenderer>().material = deactivatedMat;
                isSwitchActivated = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && isSwitchActivated == false)
        {
            foreach (GameObject doors in Interactable)
            {
                if (doors.GetComponent<LVL_Door>().isOpen)
                {
                    doors.GetComponent<LVL_Door>().Deactivate();
                }
                else
                {
                    doors.GetComponent<LVL_Door>().Activate();
                }
            }
            //Interactable.GetComponent<LVL_Door>().Activate();
            Crystal.GetComponent<MeshRenderer>().material = activatedMat;
            isSwitchActivated = true;
        }

        else if (other.gameObject.tag == "Bullet" && isSwitchActivated == true)
        {
            foreach (GameObject doors in Interactable)
            {
                if (doors.GetComponent<LVL_Door>().isOpen)
                {
                    doors.GetComponent<LVL_Door>().Deactivate();
                }
                else
                {
                    doors.GetComponent<LVL_Door>().Activate();
                }
            }
            Crystal.GetComponent<MeshRenderer>().material = deactivatedMat;
            isSwitchActivated = false;
        }
    }
}