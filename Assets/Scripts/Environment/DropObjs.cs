using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjs : MonoBehaviour {

    public float intervaltop, intervalbot, speed;
    float interval, curTime;
    public GameObject[] objects;
    public int enemiesKilled = 0;

	// Use this for initialization
	void Start () {
        interval = Random.Range(intervaltop, intervalbot);
        curTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.localScale.x > 0)
        transform.position += transform.right * speed * Time.deltaTime;
        else
            transform.position += -1 * transform.right * speed * Time.deltaTime;

        if (Time.time >= interval + curTime && enemiesKilled > 5)
        {
            var interval = Random.Range(0, objects.Length);
            Instantiate(objects[interval], this.transform.position, Quaternion.Euler(0, 0, 0));
            curTime = Time.time;
            enemiesKilled = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "ground")
        {
            var newScale = this.transform.localScale;
            newScale.x *= -1;
            this.transform.localScale = newScale;
        }
    }
}
