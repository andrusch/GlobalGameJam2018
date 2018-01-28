using UnityEngine;
public class camerafollow : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;
    public float moveSpeed =5.0f;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        offSet = transform.position - playerPrefab.transform.position;
    }

    void Update()
    {
        if ((Input.GetAxis("Horizontal"))> 0)
        {
            GameState.Instance.CameraIsMoving = true;
            

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            GameState.Instance.CameraIsMoving = true;

        }
        if (Input.GetAxis("Vertical") < 0)
        {
            GameState.Instance.CameraIsMoving = true;

        }
        if (Input.GetAxis("Vertical") < 0)
        {
            GameState.Instance.CameraIsMoving = true;

        }
        Vector3 v = new Vector3(moveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed*Input.GetAxis("Vertical") * Time.deltaTime, 0.0f);
        transform.Translate(v);
    }
}
