using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    Animator anim;
    public float comboA, comboB, punchAdmg, kickAdmg, punchBdmg, kickBdmg, punchCdmg, kickCdmg;
    float hitATime, hitBtime;
    Rigidbody2D rb;
    bool firstPunch = false, secondHit = false, kickCombo = false, punchCombo = false;
    Damage damageClass;
    EnemyHealth enemHealth;
    Grab grabClass;
    GroundCheck grounded;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemHealth = FindObjectOfType<EnemyHealth>();
        grabClass = FindObjectOfType<Grab>();
        grounded = FindObjectOfType<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (punchCombo || kickCombo)
        {
            StartCoroutine(delay());
        }

        if (grabClass.canAttack && !grounded.grounded && !punchCombo)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("punch");
            }
            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetTrigger("kick");
            }
        }
        else
        if (grabClass.canAttack && grounded.grounded)
        {
            if (Input.GetButtonDown("Fire1") && firstPunch == false && !secondHit)
            {
                anim.SetTrigger("punch");
                firstPunch = true;
                hitATime = Time.time;
            }
            else
            if (Time.time <= (hitATime + comboA) && firstPunch == true)
            {
                // Combo punch-kick or kick-punch
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("punchB");
                    firstPunch = false;
                    secondHit = true;
                    hitBtime = Time.time;
                }
            }
            else if (Time.time <= (hitBtime + comboB)  && secondHit == true)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetBool("attack", true);
                    anim.SetTrigger("punchC");
                    secondHit = false;
                    punchCombo = true;
                    grabClass.canAttack = false;
                }
            }
            else
            {
 
                firstPunch = false;
                secondHit = false;
            }

            if (Input.GetButtonDown("Fire2") && firstPunch == false && !secondHit)
            {
                hitATime = Time.time;
                firstPunch = true;
                anim.SetTrigger("kick");
              //  kickCombo = true;
            }
            else
                if (Time.time <= (hitATime + comboA) && firstPunch == true)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    anim.SetTrigger("kickB");
                    firstPunch = false;
                    secondHit = true;
                    hitBtime = Time.time;
                }
            }
            else if (Time.time <= (hitBtime + comboB) && secondHit == true)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    anim.SetTrigger("kickC");
                    secondHit = false;
                    kickCombo = true;
                    grabClass.canAttack = false;
                }
            }
            else
            {
                kickCombo = false;
                firstPunch = false;
            }
        }
    }

    public void punchA()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = punchAdmg;
        if (damageClass.hit)
        {
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }

    public void punchB()
    {
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = punchBdmg;
        if (damageClass.hit)
        {
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }

    public void punchC()
    {
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = punchCdmg;
        if (damageClass.hit)
        {
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }

    public void kickA()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = kickAdmg;
        if (damageClass.hit)
        {
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }

    public void kickB()
    {
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = kickBdmg;
        if (damageClass.hit)
        {
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }

    public void kickC()
    {
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = kickCdmg;
        if (damageClass.hit)
        {
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(.5f);
        punchCombo = false;
        kickCombo = false;
        grabClass.canAttack = true;
        anim.SetBool("attack", false);
    }

    public void uppercutDelay()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15) * 30, ForceMode2D.Impulse);
    }

    public void Freeze()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
