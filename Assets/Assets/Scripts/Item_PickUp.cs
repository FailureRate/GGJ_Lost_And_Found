using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PickUp : MonoBehaviour
{
    [SerializeField] itemState item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetItem(item);
            Destroy(this.gameObject);
        }
    }
}
