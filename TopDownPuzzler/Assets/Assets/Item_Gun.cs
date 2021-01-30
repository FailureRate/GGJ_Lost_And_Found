using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Gun : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform playerHullTransform;
    [SerializeField] private Transform gunOrigin;
    [SerializeField] private GameObject bulletRefrence;
    [SerializeField] private Light muzzelLight;

    [Header("Generics")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float fireCooldownMax;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = fireCooldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timer >= fireCooldownMax)
        {
            GameObject bullet = Instantiate(bulletRefrence, gunOrigin.position, Quaternion.identity);
            bullet.GetComponent<Item_Bullet>().SetFireVector(playerHullTransform.forward * projectileSpeed);
            Destroy(bullet, fireCooldownMax);
            StartCoroutine(MuzzleFlash());
            timer = 0.0f;
        }
    }

    private IEnumerator MuzzleFlash()
    {
        muzzelLight.enabled = true;
        yield return new WaitForSeconds(0.05f);
        muzzelLight.enabled = false;
        yield return null;
    }
}
