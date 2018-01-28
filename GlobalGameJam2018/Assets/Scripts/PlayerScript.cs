using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float moveSpeed;
    public float rotationSpeed = 20f;
    public GameObject camera;
    public Vector3 offSet;
    public float smoothSpeed = 20.0f;
 
    void Start () {
        offSet = transform.position - camera.transform.position;
        moveSpeed = 1.0f;
	}

	void Update () {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        
        transform.position = Vector3.Lerp(camera.transform.position + offSet, camera.transform.position + offSet,smoothSpeed);
        

    }
}
