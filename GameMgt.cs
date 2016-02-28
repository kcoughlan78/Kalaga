using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgt : MonoBehaviour {

    public int playerLives;
    public Text text;
    public Text levelText;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        playerLives = 3;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Lives: " + playerLives;
        levelText.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
	}
}
