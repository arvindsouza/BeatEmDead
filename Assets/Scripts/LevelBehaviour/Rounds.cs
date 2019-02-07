using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour {

    public int roundScoreLimit;
    int roundNo = 0;
    public GameObject spawnA, spawnB, congrats, Heavy, flyingSpawn;
    Score theScore;

	// Use this for initialization
	void Start () {
        theScore = FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(roundNo + " " + theScore.score + " " + roundScoreLimit);
        if (theScore.score >= roundScoreLimit || roundNo == 0)
        {
            if(roundNo != 0)
            congrats.GetComponent<Text>().text = "ROUND CLEAR!";
            else
                congrats.GetComponent<Text>().text = "";
            roundNo += 1;
            Debug.Log(roundNo + " " + theScore.score + " " + roundScoreLimit);
            var enemies = GameObject.FindGameObjectsWithTag("enemy");
            for(int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            if (roundNo == 2)
            {
                spawnA.GetComponent<Spawn>().Enemy.Add(Heavy);
            }



            spawnA.SetActive(false);
            spawnB.SetActive(false);
            flyingSpawn.SetActive(false);
            congrats.SetActive(true);
            StartCoroutine(delay());
            if(roundNo >1)
            roundScoreLimit += roundScoreLimit;

        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        congrats.GetComponent<Text>().text = "ROUND "+roundNo;
        yield return new WaitForSeconds(2f);
        congrats.GetComponent<Text>().text = "START!";
        yield return new WaitForSeconds(2f);
        congrats.SetActive(false);
        congrats.GetComponent<Text>().fontSize = 15;
        spawnA.SetActive(true);
        spawnB.SetActive(true);
        if (roundNo >= 3)
            flyingSpawn.SetActive(true);
    }
}
