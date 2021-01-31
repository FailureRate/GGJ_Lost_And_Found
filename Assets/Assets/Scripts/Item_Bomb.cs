using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bomb : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    // [SerializeField] private float timerDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //   timerDuration -= Time.deltaTime;
    //     if(timerDuration <= 0.0){
    //         Explode();
    //     }
    }

    public void Explode(){
       // Destroy(this.gameObject);
    gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-10,
        gameObject.transform.position.z);
    }
}
