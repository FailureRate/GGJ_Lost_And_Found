using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Killzone : MonoBehaviour
{
    [Header("Reset")]
    [SerializeField] private GameObject PlayerSpawn;
    [SerializeField] private GameObject Player;

    Vector3 noMomentum = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = PlayerSpawn.transform.position;
            Player.GetComponent<Rigidbody>().velocity = noMomentum;
        }
    }
}
