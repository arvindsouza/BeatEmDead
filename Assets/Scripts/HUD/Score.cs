using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
  
	// Use this for initialization
	void Start () {
        score = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = score.ToString();
	}
}
