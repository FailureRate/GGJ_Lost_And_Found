using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_ItemController : MonoBehaviour
{
    [Header("Item Bools")]
    public bool hasBomb;
    public bool hasBow;
    public bool hasHook;
    public bool hasLantern;

    private bool isLanternOn;
    private bool isBombPlaced;

    [Header("References")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject hook;

    [SerializeField] private GameObject lantern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")){
            if (hasBomb){
                if(!isBombPlaced){
                //Instantiate(bomb, this.gameObject.transform.position, this.gameObject.transform.rotation);
                isBombPlaced = true;
                bomb.transform.position = gameObject.transform.position;
            }
                else{
                     isBombPlaced = false;
                bomb.GetComponent<Item_Bomb>().Explode();
                }
            }
        }
        if(Input.GetKeyDown("q")){
            if (hasLantern){
                if(!isLanternOn){
                    isLanternOn = true;
                    this.GetComponentsInChildren<Light>()[0].enabled = true;
                }
                else{
                    isLanternOn = false;
                    this.GetComponentsInChildren<Light>()[0].enabled = false;
                }
            }
        }
    }
}