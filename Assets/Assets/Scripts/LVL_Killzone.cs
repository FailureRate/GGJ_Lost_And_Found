using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Killzone : MonoBehaviour
{
    [Header("Reset")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PlayerSpawn;
    [SerializeField] private Transform PlayerTransform;

    Vector3 noMomentum = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController CC = Player.GetComponent<CharacterController>();
            CC.enabled = false;
            Player.transform.position = PlayerSpawn.transform.position;

            CC.enabled = true;
            Debug.Log("Pew");
            //Destroy(Player);
        }
    }
}
