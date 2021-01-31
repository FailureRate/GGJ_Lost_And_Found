using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_ShootTarget : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    [Header("Material")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material deactivatedMat;

    [Header("Reference")]
    [SerializeField] private GameObject Crystal;

    private bool isSwitchActivated;
    public LVL_Door DoorScript;

    private void Update()
    {
        if(DoorScript.isOpen == true)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && isSwitchActivated == false)
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            Crystal.GetComponent<MeshRenderer>().material = activatedMat;
            isSwitchActivated = true;
        }

        else if (other.gameObject.tag == "Bullet" && isSwitchActivated == true) {
            Interactable.GetComponent<LVL_Door>().Deactivate();
            Crystal.GetComponent<MeshRenderer>().material = deactivatedMat;
            isSwitchActivated = false;
        }
    }
}