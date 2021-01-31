using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_HeavySwitch : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    [Header("Material")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material deactivatedMat;

    private bool isSwitchActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulder" && isSwitchActivated == false)
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            GetComponent<MeshRenderer>().material = activatedMat;
            isSwitchActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boulder" && isSwitchActivated == true)
        {
            Interactable.GetComponent<LVL_Door>().Deactivate();
            GetComponent<MeshRenderer>().material = deactivatedMat;
            isSwitchActivated = false;
        }
    }
}