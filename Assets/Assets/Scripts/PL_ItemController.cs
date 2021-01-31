using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_ItemController : MonoBehaviour
{
    [Header("Item Bools")]
    public bool hasBomb;
    public bool hasGun;
    public bool hasHook;
    public bool hasLantern;

    private bool isLanternOn;
    private bool isBombPlaced;

    [Header("Lantern References")]
    [SerializeField] private GameObject lantern;

    [Header("Bomb References")]
    [Tooltip("Place a Bomb Prefab in World and Refrence it")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private ParticleSystem bombExplosion;

    [Header("Bomb Generics")]
    [SerializeField] private float bombCooldownTimerMax;
    private float bombCooldownTimer;

    [Header("Gun References")]
    [SerializeField] private Transform playerHullTransform;
    [SerializeField] private Transform gunOrigin;
    [SerializeField] private GameObject bulletRefrence;
    [SerializeField] private Light muzzelLight;

    [Header("Gun Generics")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float gunCooldownTimerMax;
    private float gunCooldownTimer;

    [Header("Hook References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] GameObject HidingHole;
    [Tooltip("Place a Hook Prefab in World and Refrence it")]
    [SerializeField] private GameObject hook;

    [Header("Hook Generics")]
    [SerializeField] float distanceToPlayer;
    [SerializeField] float hookTravelSpeed;
    [SerializeField] float playerTravelSpeed;
    public static bool fired;
    [SerializeField] bool hooked;
    [SerializeField] float maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gunCooldownTimer += Time.deltaTime;
        bombCooldownTimer += Time.deltaTime;
        HookInputs();
        LightInputs();
        BombInputs();
        GunInputs();
    }

    private void LightInputs()
    {
        if (Input.GetKeyDown("q"))
        {
            if (hasLantern)
            {
                if (!isLanternOn)
                {
                    isLanternOn = true;
                    this.GetComponentsInChildren<Light>()[0].enabled = true;
                }
                else
                {
                    isLanternOn = false;
                    this.GetComponentsInChildren<Light>()[0].enabled = false;
                }
            }
        }
    }
    private void BombInputs()
    {
        if (Input.GetKeyDown("e"))
        {
            if (hasBomb)
            {
                if (!isBombPlaced && bombCooldownTimer >= bombCooldownTimerMax)
                {
                    //Instantiate(bomb, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    isBombPlaced = true;
                    bomb.transform.position = gameObject.transform.position;
                    bombExplosion.transform.position = gameObject.transform.position;
                    bombCooldownTimer = 0.0f;
                }
                else if (isBombPlaced)
                {
                    isBombPlaced = false;
                    bomb.GetComponent<Item_Bomb>().Explode();
                    bombExplosion.Play();

                }
            }
        }
    }
    private void GunInputs()
    {
        if (hasGun)
        {
            if (Input.GetKeyDown(KeyCode.Space) && gunCooldownTimer >= gunCooldownTimerMax)
            {
                GameObject bullet = Instantiate(bulletRefrence, gunOrigin.position, Quaternion.identity);
                bullet.GetComponent<Item_Bullet>().SetFireVector(playerHullTransform.forward * projectileSpeed);
                Destroy(bullet, gunCooldownTimerMax);
                StartCoroutine(MuzzleFlash());
                gunCooldownTimer = 0.0f;
            }
        }
    }
    private void HookInputs()
    {
        if (Input.GetMouseButtonDown(0) && fired == false)
            fired = true;

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(playerHullTransform.forward * Time.deltaTime * hookTravelSpeed);
            float currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }


        }


        if (hooked == true)
        {

            Vector3 something = hook.transform.position - transform.position;
            something.Normalize();

            controller.Move(something * Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);
            Debug.Log(distanceToHook);


            if (distanceToHook < distanceToPlayer)
            {
                ReturnHook();

            }


        }
        if (fired == false && hooked == false)
        {
            hook.transform.position = HidingHole.transform.position;
        }
    }
    private IEnumerator MuzzleFlash()
    {
        muzzelLight.enabled = true;
        yield return new WaitForSeconds(0.05f);
        muzzelLight.enabled = false;
        yield return null;
    }
    public void SetHookState(bool state_)
    {
        hooked = state_;
    }

    public void ReturnHook()
    {

        GameObject.Find("PRFAB_Player").GetComponent<PL_Movement>().canMove = true;
        fired = false;
        hooked = false;
        Debug.Log("test");
    }
}
