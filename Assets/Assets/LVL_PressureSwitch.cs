using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_PressureSwitch : MonoBehaviour
{
    [Header("Activatable")]
    [SerializeField] private GameObject Interactable;

    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bomb")
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            renderer.material.SetColor("_Color", Color.red);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bomb")
        {
            Interactable.GetComponent<LVL_Door>().Deactivate();
            renderer.material.SetColor("_Color", Color.white);
        }
    }
}
