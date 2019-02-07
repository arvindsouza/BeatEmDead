using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public List <GameObject> Enemy;
    public float time;
    float curTime;

	// Use this for initialization
	void Start () {
        curTime = Time.time;
        Debug.Log(transform.localRotation);
        if(transform.localScale.x > 0)
        Instantiate(Enemy[Random.Range(0,Enemy.Count)], transform.position, Quaternion.Euler(0, 0, 0));
        else
        {
         var obj =    Instantiate(Enemy[Random.Range(0, Enemy.Count)], transform.position, Quaternion.Euler(0, 0, 0));
            var newscale = obj.transform.localScale;
            newscale.x *= -1;
            obj.transform.localScale = newscale;
        }
    }

    // Update is called once per frame
    void Update () {
		if(time + curTime < Time.time)
        {
            if (transform.localScale.x > 0)
                Instantiate(Enemy[Random.Range(0, Enemy.Count)], transform.position, Quaternion.Euler(0, 0, 0));
            else
            {
                var obj = Instantiate(Enemy[Random.Range(0, Enemy.Count)], transform.position, Quaternion.Euler(0, 0, 0));
                var newscale = obj.transform.localScale;
                newscale.x *= -1;
                obj.transform.localScale = newscale;
            }
            curTime = Time.time;
        }
	}
}
