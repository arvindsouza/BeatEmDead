using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool grounded = true;
    public Rigidbody2D rb;
    public float fallMultiplier, lowFallMultiplier;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowFallMultiplier - 1) * Time.deltaTime;
        }
    
}

void OnTriggerEnter2D(Collider2D coll)
{
    if (coll.tag == "ground")
    {
        grounded = true;
    }
}

void OnTriggerStay2D(Collider2D coll)
{
    if (coll.tag == "ground")
    {
        grounded = true;
    }

}

void OnTriggerExit2D(Collider2D coll)
{
    if (coll.tag == "ground")
        grounded = false;
}
}
