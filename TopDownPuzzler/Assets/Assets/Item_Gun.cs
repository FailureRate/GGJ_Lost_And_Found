using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Gun : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform playerHullTransform;
    [SerializeField] private Transform gunOrigin;
    [SerializeField] private GameObject bulletRefrence;

    [Header("Generics")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletRefrence, gunOrigin.position, Quaternion.identity);
            bullet.GetComponent<Item_Bullet>().SetFireVector(playerHullTransform.forward * projectileSpeed);
            Destroy(bullet, 1.0f);
        }
    }
}
