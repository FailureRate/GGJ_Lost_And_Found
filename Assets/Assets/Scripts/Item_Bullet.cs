using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bullet : MonoBehaviour
{

    public Vector3 fireVector;
    [SerializeField] private float hitBulletLife = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(fireVector * Time.deltaTime);
    }

    public void SetFireVector(Vector3 direction)
    {
        fireVector = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enviorment"))
        {
            fireVector = Vector3.zero;
            Debug.Log(other.gameObject.tag);
            Destroy(this.gameObject, hitBulletLife);
        }
    }

    
}
