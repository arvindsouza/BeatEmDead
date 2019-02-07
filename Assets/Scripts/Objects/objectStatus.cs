using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStatus : MonoBehaviour {

    bool holding = false;
    float counter = 0;
    public GameObject destroy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D coll)
    {

            if (coll.tag == "ground" && !holding)
        {
             counter++;
              if(counter == 4)
               {
                   Instantiate(destroy, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                   Destroy(this.gameObject);
               }   
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            holding = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            holding = false;
        }
    }

}
