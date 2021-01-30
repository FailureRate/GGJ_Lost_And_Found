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

    private bool Activated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && Activated == false)
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            Crystal.GetComponent<MeshRenderer>().material = activatedMat;
            Activated = true;
        }

        else if (other.gameObject.tag == "Bullet" && Activated == true) {
            Interactable.GetComponent<LVL_Door>().Deactivate();
            Crystal.GetComponent<MeshRenderer>().material = deactivatedMat;
            Activated = false;
        }
    }
}