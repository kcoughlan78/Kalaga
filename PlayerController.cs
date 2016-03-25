using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject laserredPrefab;
    private AudioSource audioplay;
    public AudioClip audioplayBoom;
    public AudioClip enemyHit;
    private enemyFire enemyFire;
    private GameObject fire;
    float xmin;
    float xmax;
    public float missileSpeed = 4;
    public float launchRate = 0.2f;
    public float defenses = 199;
    public float damage;

    //scoring
    private GameMgt gameMgt;
    public int playerHit = 100;
    public int playerKill = 200;



    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftLimit.x;
        xmax = rightLimit.x;

        damage = 0;

        gameMgt = GameObject.FindObjectOfType<GameMgt>();
        audioplay = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        ShipControl();
        ShipAnimate();
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("ShipFire", 0.000001f, launchRate);
        }

        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("ShipFire");
        }
    }

    void ShipAnimate()
    {
        if(Input.GetAxis("Mouse X") < 0)
        {
            print("Mouse left");
        }else if (Input.GetAxis("Mouse X") > 0)
        {
            print("Mouse right");
        }else if (Input.GetAxis("Mouse X") == 0)
        {
            print("Mouse Still");
        }   
    }

    void ShipControl()
    {
        Vector3 ShipPos = new Vector3(0.29f, this.transform.position.y, 0f);
        float MousePosBlocks = (Input.mousePosition.x / Screen.width) * 11;
        ShipPos.x = Mathf.Clamp(MousePosBlocks, xmin, xmax);
        this.transform.position = ShipPos;
    }

    void ShipFire()
    {
        
            fire = Instantiate(laserredPrefab, transform.position, Quaternion.identity) as GameObject;
            fire.GetComponent<Rigidbody2D>().velocity = new Vector3(0, missileSpeed, 0);
            audioplay.Play();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Ammunition")
        {
            print("Safe");
        }
        else if (trigger.tag == "EnemyAmmo")
        {
            enemyFire enemyMissile = trigger.gameObject.GetComponent<enemyFire>();
            damage += enemyMissile.enemylaserDamage;
            if (enemyMissile && defenses > damage)
            {
                Destroy(trigger.gameObject);
                gameMgt.Score = gameMgt.Score - playerHit;
                AudioSource.PlayClipAtPoint(enemyHit, transform.position);
                print("Missile Destroyed");
            }
            else if (enemyMissile && defenses <= damage)
            {
                Destroy(trigger.gameObject);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(audioplayBoom, transform.position);
                gameMgt.Score = gameMgt.Score - playerKill;
                gameMgt.playerLives--;
                print("Missile Destroyed");
                
            }

        }
    }
}
