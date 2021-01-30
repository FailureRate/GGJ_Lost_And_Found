using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bomb : MonoBehaviour
{

     [SerializeField] private float timerDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      timerDuration -= Time.deltaTime;
        if(timerDuration <= 0.0){
            Explode();
        }
    }

    void Explode(){
        Destroy(this.gameObject);
    }
}
