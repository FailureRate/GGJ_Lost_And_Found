using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HookDetector : MonoBehaviour
{
    public Item_GrappleHook PRFAB_Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hookable")
        {
            PRFAB_Player.GetComponent<Item_GrappleHook>().SetHookState(true);

        }
        
        if (other.tag == "Enviorment")
        {
            PRFAB_Player.ReturnHook();
        }

        if (other.tag == "Boulder")
        {
            PRFAB_Player.ReturnHook();
        }
    }
}
 