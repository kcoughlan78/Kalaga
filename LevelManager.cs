using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameMgt gameMgt;
    public scoreKeep scoreKeep;

    void Start()
    {
        gameMgt = GameObject.FindObjectOfType<GameMgt>();
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void ReturnToStart(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
        scoreKeep.StartScore = 0;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
