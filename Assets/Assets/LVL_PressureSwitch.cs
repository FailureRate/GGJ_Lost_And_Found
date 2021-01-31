using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_PressureSwitch : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    [Header("Material")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material deactivatedMat;

    private bool isSwitchActivated;

    private void Update()
    {
        if(isSwitchActivated == true)
        {
            Interactable.GetComponent<LVL_Door>().Activate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interactable.GetComponent<LVL_Door>().Activate();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bomb")
        {
            GetComponent<MeshRenderer>().material = activatedMat;
            isSwitchActivated = true;
}
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Bomb") && isSwitchActivated == true)
        {
            Interactable.GetComponent<LVL_Door>().Deactivate();
            GetComponent<MeshRenderer>().material = deactivatedMat;
            isSwitchActivated = false;
        }
    }
}