using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 9;
    public float height = 5;
    private bool movingRight = true;
    public float speed = 2;
    private float enemyXMin;
    private float enemyXMax;
    private float startForm;

    // Use this for initialization
    void Start () {
        startForm = Random.Range(0, 1);

        if (startForm == 0)
        {
            movingRight = false;
        }
        else
        {
            movingRight = true;
        }

        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftedge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightedge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        enemyXMin = leftedge.x;
        enemyXMax = rightedge.x;


        foreach ( Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
    
	
	// Update is called once per frame
	void Update () {

        if(transform.position.x >= (enemyXMax - (width/2)))
        {
            movingRight = false;
        }else if (transform.position.x <= (enemyXMin + (width/2)))
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

	    
	}
}
