using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    bool canGrab = false;
    public bool grabbing = false;
    GameObject item;
    public GameObject grab, bottom, backArm, frontArm, weapon;
    public bool canAttack = true;
    public float force, upwardForce;
    WeaponDmg weaponStatus;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grab") && !grabbing && canGrab)
        {
            canGrab = false;
            grabbing = true;
            canAttack = false;
            if(item && item.tag == "grabable")
            GetComponent<Animator>().SetTrigger("grab");
            StartCoroutine(delay());
            if (transform.localScale.x < 0)
                item.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            else
                item.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        if (Input.GetButtonDown("Grab") && grabbing == true)
        {
            grabbing = false;
            canAttack = true;
            if(item.transform.childCount > 1)
            item.transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(ThrowDelay());
            item.GetComponent<Rigidbody2D>().velocity = new Vector3(1 * force * transform.localScale.x, 1 * upwardForce, 0);
        }


        if (grabbing == true)
        {
            if(item.tag != "weapon")
            item.transform.position = grab.transform.position;
            else
            {
                weaponStatus = FindObjectOfType<WeaponDmg>();
                if (weaponStatus && weaponStatus.counter >= 2)
                {
                    Destroy(item);
                    grabbing = false;
                    canAttack = true;
                    bottom.SetActive(false);
                    GetComponent<SpriteRenderer>().enabled = true;
                }
                item.transform.position = weapon.transform.position;
                if (Input.GetButtonDown("Fire1"))
                {
                    bottom.GetComponent<Animator>().SetTrigger("attack");
                }

            }
            if (transform.localScale.x < 0)
                item.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            else
                item.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!grabbing && coll.tag == "grabable")
        {
            canGrab = true;
            item = coll.gameObject;
        }

        if(!grabbing && coll.tag == "weapon")
        {
            canGrab = true;
            item = coll.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (!grabbing && coll.tag == "grabable")
        {
            canGrab = true;
            item = coll.gameObject;
        }

        if (!grabbing && coll.tag == "weapon")
        {
            canGrab = true;
            item = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (!grabbing && coll.tag == "grabable")
        {
            canGrab = false;
        }

        if (!grabbing && coll.tag == "weapon")
        {
            canGrab = false;
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(.18f);
        GetComponent<SpriteRenderer>().enabled = false;
        bottom.SetActive(true);
        if (item.tag == "weapon")
        {
            bottom.GetComponent<Animator>().SetBool("weapon", true);
            frontArm.SetActive(true);
        }
        else
        backArm.SetActive(true);
    }

    IEnumerator ThrowDelay()
    {
        backArm.SetActive(false);
        bottom.GetComponent<Animator>().SetTrigger("throw");
        if(item.tag == "weapon")
            frontArm.SetActive(false);
        yield return new WaitForSeconds(.2f);
        bottom.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
