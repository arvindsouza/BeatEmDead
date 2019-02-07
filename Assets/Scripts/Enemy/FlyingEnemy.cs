using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    GameObject target;
    public float speed, rof;
    Damage damageClass;
    PlayerHealth playerhlth;
    public Canvas theCanvas;
    public GameObject Bomb;
    float lastFire;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Protagonist");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0)
        {
            var newscale = transform.localScale;
            newscale.x = -1;
            theCanvas.transform.localScale = newscale;
        }
        else
        {
            var newscale = transform.localScale;
            newscale.x = 1;
            theCanvas.transform.localScale = newscale;
        }

        if (target)
        {
            if (transform.position.x != target.transform.position.x)
            {
                if (transform.position.x > target.transform.position.x)
                {
                    if (transform.localScale.x < 0)
                    {
                        var newscale = transform.localScale;
                        newscale.x *= -1;
                        transform.localScale = newscale;
                    }
                    if (transform.position.x > target.transform.position.x + 2)
                        transform.position += transform.right * -1 * speed * Time.deltaTime;
                }
                else
                {
                    if (transform.localScale.x > 0)
                    {
                        var newscale = transform.localScale;
                        newscale.x *= -1;
                        transform.localScale = newscale;
                    }

                    if (transform.position.x < target.transform.position.x - 2)
                        transform.position += transform.right * speed * Time.deltaTime;
                }
            }


            if (transform.localScale.x > 0)
            {
                if ((transform.position.x <= target.transform.position.x + 2 && transform.position.x >= target.transform.position.x) || transform.position.x == target.transform.position.x)
                {
                    if(Time.time > lastFire + rof)
                    {
                        Instantiate(Bomb, transform.position, Quaternion.Euler(0, 0, 0));
                        lastFire = Time.time;
                    }
                }
            }
            else
            {
                if ((transform.position.x >= target.transform.position.x - 2 && transform.position.x <= target.transform.position.x) || transform.position.x == target.transform.position.x)
                {
                    if (Time.time > lastFire + rof)
                    {
                        Instantiate(Bomb, transform.position, Quaternion.Euler(0, 0, 0));
                        lastFire = Time.time;
                    }
                }
            }

        }
    }
}
