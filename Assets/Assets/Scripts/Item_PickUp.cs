using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PickUp : MonoBehaviour
{
    [SerializeField] itemState item;
    [SerializeField] GameObject toolTipPane;
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
            if (toolTipPane)
            {
                toolTipPane.SetActive(true);
            }
            GameManager.Instance.SetItem(item);
            Destroy(this.gameObject);
        }
    }
}
