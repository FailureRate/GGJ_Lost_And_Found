using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_BoulderSpawn : MonoBehaviour
{
    [Header("Reset")]
    [SerializeField] private GameObject BoulderSpawn;
    [SerializeField] private GameObject Boulder;

    [Header("Material")]
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material deactivatedMat;

    Vector3 noMomentum = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material = activatedMat;
            Boulder.transform.position = BoulderSpawn.transform.position;
            Boulder.GetComponent<Rigidbody>().velocity = noMomentum;
            GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material = deactivatedMat;
        }
    }
}