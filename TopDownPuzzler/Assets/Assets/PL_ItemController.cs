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

    [Header("References")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject hook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")){
            if (hasBomb == true){
                Instantiate(bomb, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
        }
    }
}
