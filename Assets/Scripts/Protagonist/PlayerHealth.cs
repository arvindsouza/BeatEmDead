using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float initHealth;
    float curHealth;
    public GameObject gameOverMenu;

    //HUD
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        curHealth = initHealth;
        healthSlider.maxValue = initHealth;
        healthSlider.value = curHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        curHealth -= damage;
        healthSlider.value = curHealth;
        if (curHealth <= 0)
        {
            GetComponent<Animator>().SetTrigger("death");
            StartCoroutine(deathDelay());
            foreach (var x in GameObject.FindGameObjectsWithTag("spawn")) {
                Destroy(x);
            };
        }
    }

    IEnumerator deathDelay()
    {
        gameOverMenu.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    public void addHealth(float healthamt)
    {
        if(curHealth < initHealth)
        {
            curHealth += healthamt;
            healthSlider.value = curHealth;
        }
    }
}
