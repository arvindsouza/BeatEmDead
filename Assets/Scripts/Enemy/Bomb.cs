using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
           if(coll.GetComponent<PlayerHealth>() != null)
            coll.GetComponent<PlayerHealth>().addDamage(damage);
            Destroy(gameObject);
        }
    }

}
