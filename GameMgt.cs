using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgt : MonoBehaviour {

    public int playerLives;
    public int Score;
    public Text livesText;
    public Text scoreText;
    public Text playerMsg;
    //private LevelManager levelManager;
    private PlayerController player;
    


    // Use this for initialization
    void Start () {
        playerLives = 3;
        Score = 0;
        //levelManager = GameObject.FindObjectOfType<LevelManager>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        livesText.text = "Lives: " + playerLives;
        scoreText.text = "Score: " + Score;
        if(player.damage > 100)
        {
            playerMsg.text = "Shields damaged";
        }
        else
        {
            playerMsg.text = "Enemy Alert";
        }
	}
}
