using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed, jumpforce;
    public Rigidbody2D rb;
    public GameObject groundCollider, playerBottom;
    GroundCheck groundcheck;
    Animator anim;
    public bool canWalk = true;

    // Use this for initialization
    void Start()
    {
        groundcheck = FindObjectOfType<GroundCheck>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk
        if (canWalk) { 
        transform.position += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (groundcheck.grounded)
            anim.SetBool("jump", false);

        //Jump Stuff
        if (Input.GetButtonDown("Jump") && groundcheck.grounded && canWalk)
        {
            anim.SetBool("jump", true);
            rb.velocity = new Vector3(0, 1, 0) * jumpforce;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("walking", true);
            if (playerBottom.activeSelf)
            {
                playerBottom.GetComponent<Animator>().SetBool("walking", true);
            }
            while (transform.localScale.x > 0)
            {
                var newscale = transform.localScale;
                newscale.x *= -1;
                transform.localScale = newscale;
            }
        }
        else

                if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("walking", true);
            if (playerBottom.activeSelf)
            {
                playerBottom.GetComponent<Animator>().SetBool("walking", true);
            }
            while (transform.localScale.x < 0)
            {
                var newscale = transform.localScale;
                newscale.x *= -1;
                transform.localScale = newscale;
            }
        }
        else
        {
            anim.SetBool("walking", false);
            if (playerBottom.activeSelf)
            {
                playerBottom.GetComponent<Animator>().SetBool("walking", false);
            }
        }
        }

    }
}
