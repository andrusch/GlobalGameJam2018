using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float moveSpeed;
    public float rotationSpeed = 20f;
    public GameObject camera;
    public Vector3 offSet;
    public Vector3 b = new Vector3(1f,0f,0f);
    public float smoothSpeed = 20.0f;
    private Animator animator;
    void Start () {
        animator = GetComponent<Animator>();
        offSet = transform.position - camera.transform.position;
        moveSpeed = 1.0f;
	}

	void Update () {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (GameState.Instance.CameraIsMoving)
        {
            animator.SetTrigger("run");
        }
        transform.position = Vector3.Lerp(camera.transform.position + offSet, camera.transform.position + offSet,smoothSpeed);
        

    }
}
