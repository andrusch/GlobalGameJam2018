using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int defensePoints = 10;
    private int pointValAtDeath = 0;
    private bool isDead = false;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (defensePoints <= pointValAtDeath && isDead == false)
        {
            Debug.Log("Barrier Destroyed!" + "; isDead = " + isDead); //Testing
            isDead = true;
            Destroy(gameObject);
        }

        //Testing
        Debug.Log("Barrier Life = " + defensePoints.ToString() + "; isDead = " + isDead);
        defensePoints -= 1;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider Tag = " + collision.gameObject.tag); //Testing
        if (collision.gameObject.tag == "Projectile")
            defensePoints -= 1;
    }

}
