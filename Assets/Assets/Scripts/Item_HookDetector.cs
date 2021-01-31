using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HookDetector : MonoBehaviour
{
    public Item_GrappleHook Playerholder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hookable")
        {
            Playerholder.GetComponent<Item_GrappleHook>().SetHookState(true);

        }
        
    }
}
 