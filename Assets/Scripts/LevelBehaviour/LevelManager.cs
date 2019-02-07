using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    bool isPaused = false;
    public GameObject pauseMenu, wall;
    public int speed;
    Movement playerMove;
    public GameObject player;
    Vector3 initPos;

	// Use this for initialization
	void Start () {
        playerMove = FindObjectOfType<Movement>();
        playerMove.canWalk = false;
        initPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (playerMove.transform.position.x < initPos.x + 20 && !playerMove.canWalk)
        {
            playerMove.transform.position += transform.right * playerMove.moveSpeed * Time.deltaTime;
            player.GetComponent<Animator>().SetBool("walking", true);
        }
else        {
            playerMove.canWalk = true;
            wall.SetActive(true);
        }

        if (Input.GetButtonDown("Cancel"))
                Pause();
	}

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = !isPaused;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }else
        {
            isPaused = !isPaused;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    void unPause()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
