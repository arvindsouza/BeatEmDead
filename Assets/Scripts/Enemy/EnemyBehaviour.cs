using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

     GameObject target;
    public float speed, punchDmg;
    Damage damageClass;
    PlayerHealth playerhlth;
    public Canvas theCanvas;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Protagonist");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < 0)
        {
            var newscale = transform.localScale;
            newscale.x = -1;
            theCanvas.transform.localScale = newscale;
        }else
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
                    if(transform.localScale.x > 0)
                    {
                        var newscale = transform.localScale;
                        newscale.x *= -1;
                        transform.localScale = newscale;
                    }

                    if (transform.position.x < target.transform.position.x - 2)
                        transform.position += transform.right * speed * Time.deltaTime;
                }
                GetComponent<Animator>().SetBool("walking", true);
            }


            if(transform.localScale.x > 0)
            {
                if ((transform.position.x <= target.transform.position.x + 2 && transform.position.x >= target.transform.position.x) || transform.position.x == target.transform.position.x)
                {
                    GetComponent<Animator>().SetBool("walking", false);
                    GetComponent<Animator>().SetTrigger("attack");
                }
            }
            else
            {
                if ((transform.position.x >= target.transform.position.x - 2 && transform.position.x <= target.transform.position.x) || transform.position.x == target.transform.position.x)
                {
                    GetComponent<Animator>().SetBool("walking", false);
                    GetComponent<Animator>().SetTrigger("attack");
                }
            }

        }
    }

    void Punch()
    {
        damageClass = FindObjectOfType<Damage>();
        if (damageClass.hit)
        {
            playerhlth = FindObjectOfType<PlayerHealth>();
            playerhlth.addDamage(punchDmg);
            damageClass.hit = false;
        }
    }


}
