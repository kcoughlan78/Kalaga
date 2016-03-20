using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgt : MonoBehaviour {

    public int playerLives;
    public int Score = 0;
    public Text livesText;
    public Text scoreText;
    public Text playerMsg;
    private LevelManager levelManager;
    private PlayerController player;
    public int StartScore = 0;
    public int StartLives = 1;



    // Use this for initialization
    void Start () {
        playerLives = 1;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
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

        if(playerLives == 0)
        {
            levelManager.LoadLevel("Lose");
        }
	}
}
