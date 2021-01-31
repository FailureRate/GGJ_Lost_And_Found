using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_ToggleSwitch : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    [Header("Material")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material deactivatedMat;


    private bool isSwitchActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isSwitchActivated == false)
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            GetComponent<MeshRenderer>().material = activatedMat;
            GetComponent<AudioSource>().Play();
            isSwitchActivated = true;
        }
    }
}