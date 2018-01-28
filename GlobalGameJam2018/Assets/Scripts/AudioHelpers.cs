using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelpers : MonoBehaviour {

    public AudioSource mySource;
    public AudioClip MrTHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void PlayMrTHitSound()
    {
        mySource.PlayOneShot(MrTHit);
    }
}
