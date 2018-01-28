using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrT : MonoBehaviour {
    public float MoveSpeed = 2;
    public float PatrolDistance = 40;
    public float PatrolSpeed = 1;
    public Transform PlayerPrefab;
    public Transform NucleusPrefab;
    public int moveCounter = 10;
    private bool isWithinTrigger = false;
    private int Counter = 0; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isWithinTrigger)
        {
            Move(PlayerPrefab.position, MoveSpeed);
        }
        else{
            if(Counter == moveCounter){
                Vector3 randomPosition = UnityEngine.Random.insideUnitSphere * PatrolDistance;
                randomPosition += NucleusPrefab.transform.position;
                Move(randomPosition, PatrolSpeed);
                Counter = 0;
            }
            else{
                transform.Translate(Vector3.up * Time.deltaTime * PatrolSpeed);
                Counter += 1;    
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == PlayerPrefab.name)
            isWithinTrigger = true;    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == PlayerPrefab.name)
            isWithinTrigger = true;    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == PlayerPrefab.name)
            isWithinTrigger = false;    
    }
    private void Move(Vector3 target, float speed)
    {
        float distanceToTarget = Vector3.Distance(transform.position, target);
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    void Explode() {
        
    }
    void PlayPoppingSound() {
        
    }
}
