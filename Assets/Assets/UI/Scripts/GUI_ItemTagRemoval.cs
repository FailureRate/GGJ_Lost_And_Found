using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_ItemTagRemoval : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Image[] imageArray;

    [Header("Toggles")]
    [SerializeField] private bool Lantern;
    [SerializeField] private bool Gun;
    [SerializeField] private bool Bomb;
    [SerializeField] private bool Hook;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Image image in imageArray)
        {
            // Check Gamemanager if they should be on or off
            image.enabled = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.playerHasLantern);
        if (Lantern && imageArray[0].enabled == false)
        {
            imageArray[0].enabled = true;
        }
        if (Gun && imageArray[1].enabled == false && GameManager.playerHasGun)
        {
            imageArray[1].enabled = true;
        }
        if (Bomb && imageArray[2].enabled == false && GameManager.playerHasBomb)
        {
            imageArray[2].enabled = true;
        }
        if (Hook && imageArray[3].enabled == false && GameManager.playerHasHook)
        {
            imageArray[3].enabled = true;
        }
        Lantern = GameManager.playerHasLantern;
        Gun = GameManager.playerHasGun;
        Bomb = GameManager.playerHasBomb;
        Hook = GameManager.playerHasHook;
    }
}
