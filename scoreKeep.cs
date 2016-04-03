using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreKeep : MonoBehaviour {

    public static int StartScore = 0;
    public Text finalScore;
    public GameMgt gameMgt;

    // Use this for initialization
    void Start () {

        finalScore.text = StartScore.ToString();

	
	}
}
    