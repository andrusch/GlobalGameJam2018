using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float moveSpeed;
	// Use this for initialization
	void Start () {
        moveSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.Translate(v);
        //transform.Translate(moveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime,0.0f);

    }
}
