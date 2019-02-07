using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damage;
    public bool hit;
    EnemyHealth enemHealth;
    public GameObject effect;

    // Use this for initialization
    void Start () {
        hit = false;
        enemHealth = FindObjectOfType<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "enemy" && this.tag == "Player")
        {
            coll.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,0), ForceMode2D.Impulse);
            hit = true;
            Instantiate(effect, coll.transform.position, Quaternion.Euler(0, 0, 0));
            enemHealth = coll.GetComponent<EnemyHealth>();
        }
        else
            if(coll.tag=="Player" && this.tag == "enemy")
        {
            coll.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
            hit = true;
            Instantiate(effect, coll.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    public void enemyHit()
    {
        enemHealth.addDamage(damage);
    }

}
