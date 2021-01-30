using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Switch : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PRFAB_Player" || other.gameObject.name == "Bomb")
        {
            Interactable.GetComponent <LVL_Door>().Activate();
        }
    }
}
