using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float initHealth;
    float curHealth;
    public bool hit;
    DropObjs countKills;
    public int enemNum = 0, dropRate;
    Score theScore;
    public GameObject pickups;

    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        curHealth = initHealth;
        countKills = FindObjectOfType<DropObjs>();
        theScore = FindObjectOfType<Score>();
        healthSlider.maxValue = initHealth;
        healthSlider.value = curHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

     public void addDamage(float damage)
    {
        curHealth -= damage;
        if(GetComponent<Animator>() != null)
        GetComponent<Animator>().SetTrigger("hit");
        healthSlider.value = curHealth;
        if (curHealth <= 0)
        {
            var random = Random.Range(0, 100);
            countKills.enemiesKilled += 1;
            theScore.score += 10;
            if(random <= dropRate)
            {
                Instantiate(pickups, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            Destroy(gameObject);
        }
    } 
}
