using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fontSize : MonoBehaviour {

    string theText;
    public int size;

    // Use this for initialization
    void Start() {
        theText = GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        if(GetComponent<Text>().fontSize < 30)
        {
                GetComponent<Text>().fontSize += 1;
                yield return new WaitForSeconds(.1f);
        }
   
    }
}
