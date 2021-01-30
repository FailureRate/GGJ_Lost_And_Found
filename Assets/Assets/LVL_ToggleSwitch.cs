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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bomb")
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            GetComponent<MeshRenderer>().material = activatedMat;
        }
    }
}
