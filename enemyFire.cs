using UnityEngine;
using System.Collections;

public class enemyFire : MonoBehaviour {

    private PlayerController player;

    public float enemylaserDamage;

    // Use this for initialization
    void Start () {

        player = GameObject.FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
