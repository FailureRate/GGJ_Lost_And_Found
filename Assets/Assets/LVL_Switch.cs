using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Switch : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PRFAB_Player" || other.gameObject.name == "Bomb")
        {
            Interactable.GetComponent<LVL_Door>().Activate();
        }
    }
}
