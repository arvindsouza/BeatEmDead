using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    PlayerHealth health;
    public float healthamt;
   // Movement ape;

	// Use this for initialization
	void Start () {
        health = FindObjectOfType<PlayerHealth>();
     //   ape = FindObjectOfType<Walk>();
            }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
       //S     ape.didpick = true;
            health.addHealth(healthamt);
            Destroy(gameObject);
        }
    }

}
