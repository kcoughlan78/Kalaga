using UnityEngine;
using System.Collections;

public class laserFire : MonoBehaviour {

    private enemyBehaviour enemyShips;

    public float laserDamage;

	// Use this for initialization
	void Start () {

        enemyShips = GameObject.FindObjectOfType<enemyBehaviour>();
	
	}
	
	// Update is called once per frame
	void Update () {


	}

   



}
