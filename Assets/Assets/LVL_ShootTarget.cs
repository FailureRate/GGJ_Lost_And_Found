using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_ShootTarget : MonoBehaviour
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
        if (other.gameObject.tag == "Bullet")
        {
            Interactable.GetComponent<LVL_Door>().Activate();
            renderer.material.SetColor("_Color", Color.red);
        }
    }
}
