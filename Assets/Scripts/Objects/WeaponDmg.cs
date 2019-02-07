using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDmg : MonoBehaviour
{

    Damage damageClass;
    EnemyHealth enemHealth;
    public float weaponDmg;
    public int counter = 0;

    // Use this for initialization
    void Start()
    {
        damageClass = FindObjectOfType<Damage>();
        enemHealth = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attack()
    {
        damageClass = FindObjectOfType<Damage>();
        damageClass.damage = weaponDmg;
        if (damageClass.hit)
        {
            ++counter;
            damageClass.enemyHit();
            damageClass.hit = false;
        }
    }
}
