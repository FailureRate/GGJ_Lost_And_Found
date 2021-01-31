using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Killzone : MonoBehaviour
{
    [Header("Reset")]
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform PlayerSpawn;
    [SerializeField] private Transform PlayerTransform;

    Vector3 noMomentum = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(PlayerTransform, PlayerSpawn.position, PlayerSpawn.rotation);
            Destroy(Player);
        }
    }
}
