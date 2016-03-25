using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {

    private laserFire laserFire;        //player firepower
    private enemyFire enemyFire;       //enemy firepower
    public GameObject SulthraxianMissile;   //enemy laser
    //public AudioSource[] sounds;
    public AudioClip audioplayLaser;
    public AudioClip audioplayBang;
    public AudioClip audioplayHit;
    private GameObject enemylaser; 
    public float missileSpeed = -3f;
    public float launchRate = 10f;

    public float shield;
    private float damage;

    //My firing rate solution
    private float enemyFireRange;
    private float enemyFireRangeMin = 1f;
    private float enemyFireRangeMax = 30f;

    //udemy solution
    public float fireRate = 0.4f;

    //scoring
    private GameMgt gameMgt;
    public int SulthraxianHit = 50;
    public int SulthraxianKill = 100;


    // Use this for initialization
    void Start () {

        damage = 0;
        gameMgt = GameObject.FindObjectOfType<GameMgt>();
        //sounds = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //enemyFireRange = Random.Range(enemyFireRangeMin, enemyFireRangeMax);
        //print(enemyFireRange);

        float probability = Time.deltaTime * fireRate;


        if (Random.value < probability)
        {
            Invoke("SulthraxianFire", 2f);
        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (trigger.tag == "EnemyAmmo")
        {
            print("Safe");
        }
        else if (trigger.tag == "Ammunition")
        {
            laserFire missile = trigger.gameObject.GetComponent<laserFire>();
            damage += missile.laserDamage;
            if (missile && shield > damage)
            {
                AudioSource.PlayClipAtPoint(audioplayHit, transform.position);
                Destroy(trigger.gameObject);
                print("enemyMissile Destroyed");
                gameMgt.Score = gameMgt.Score + SulthraxianHit;
            }
            else if (missile && shield <= damage)
            {
                AudioSource.PlayClipAtPoint(audioplayBang, transform.position);
                Destroy(trigger.gameObject);
                Destroy(gameObject);
                gameMgt.Score = gameMgt.Score + SulthraxianKill;
                gameMgt.playerMsg.text = "Got him!";
                print("enemyMissile Destroyed");
            }
        }

    }

    void SulthraxianFire()
    {

        enemylaser = Instantiate(SulthraxianMissile, transform.position, Quaternion.identity) as GameObject;
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, missileSpeed, 0);
        AudioSource.PlayClipAtPoint(audioplayLaser, transform.position);
    }
}
