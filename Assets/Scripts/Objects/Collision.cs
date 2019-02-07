using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject destroy;
    public float damage;
    EnemyHealth enem;
    bool holding = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "enemy")
        {
            enem = coll.gameObject.GetComponent<EnemyHealth>();
            enem.addDamage(damage);
            if(coll.GetComponent<Animator>() != null)
            coll.GetComponent<Animator>().SetTrigger("hit");
            Instantiate(destroy, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
            if(coll.tag == "ground" && !holding)
        {
            gameObject.SetActive(false);
        }
    }


}
