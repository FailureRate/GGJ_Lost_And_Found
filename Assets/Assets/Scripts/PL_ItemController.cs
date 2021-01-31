using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_ItemController : MonoBehaviour
{
    [Header("Button Controls")]
    [SerializeField] KeyCode lanternButton;
    [SerializeField] KeyCode bombButton;
    [SerializeField] int gunMouseCode;
    [SerializeField] int hookMouseCode;

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

    [Header("Sfx")]
    public AudioClip bombSound;
    public AudioClip gun;
    public AudioClip hookSound;

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
        CheckManager();
    }

    private void LightInputs()
    {
        if (Input.GetKeyDown(lanternButton))
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
        if (Input.GetKeyDown(bombButton))
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
                    GetComponent<AudioSource>().clip = bombSound;
                    GetComponent<AudioSource>().Play();
                    bombExplosion.Play();

                }
            }
        }
    }
    private void GunInputs()
    {
        if (hasGun)
        {
            if (Input.GetMouseButtonUp(gunMouseCode) && gunCooldownTimer >= gunCooldownTimerMax)
            {
                GameObject bullet = Instantiate(bulletRefrence, gunOrigin.position, Quaternion.identity);
                bullet.GetComponent<Item_Bullet>().SetFireVector(playerHullTransform.forward * projectileSpeed);
                GetComponent<AudioSource>().clip = gun;
                GetComponent<AudioSource>().Play();
                Destroy(bullet, gunCooldownTimerMax);
                StartCoroutine(MuzzleFlash());
                gunCooldownTimer = 0.0f;
            }
        }
    }
    private void HookInputs()
    {
        if (hasHook)
        {
            if (Input.GetMouseButtonDown(hookMouseCode) && fired == false){
                fired = true;
                GetComponent<AudioSource>().clip = hookSound;
                GetComponent<AudioSource>().Play();
            }
               

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
                //Debug.Log(distanceToHook);


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
    }

    private void CheckManager()
    {
        hasBomb = GameManager.playerHasBomb;
        hasGun = GameManager.playerHasGun;
        hasHook = GameManager.playerHasHook;
        hasLantern = GameManager.playerHasLantern;
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
        //Debug.Log("test");
    }
}
