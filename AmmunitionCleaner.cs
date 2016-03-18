using UnityEngine;
using System.Collections;

public class AmmunitionCleaner : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Ammunition")
        {
            Destroy(trigger.gameObject);
            print("Missile Destroyed");
        } else if (trigger.gameObject.tag == "EnemyAmmo")
        {
            Destroy(trigger.gameObject);
            print("Missile Destroyed");
        }

    }
}
