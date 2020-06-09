using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_01 : MonoBehaviour
{

    public float speed = 10;
    float lifetime;
    void Start()
    {
        lifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        Vector3 position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime,transform.position.z);
        transform.position = position;

        if(lifetime > 2f) {
            lifetime = 0;
            gameObject.SetActive(false);
            
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "cover")
        {
            Unit e = other.transform.parent.gameObject.GetComponent<Unit>();
            if(e != null) { e.Hit(); }
            gameObject.SetActive(false);
        }
        
    }
}
