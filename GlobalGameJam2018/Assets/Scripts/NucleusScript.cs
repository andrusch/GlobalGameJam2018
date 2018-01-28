using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleusScript : MonoBehaviour {

    public int NucleusHealth = 4;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == PlayerPrefab.name)
            //isWithinTrigger = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.name == PlayerPrefab.name)
            //isWithinTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.name == PlayerPrefab.name)
            //isWithinTrigger = false;
    }
}
