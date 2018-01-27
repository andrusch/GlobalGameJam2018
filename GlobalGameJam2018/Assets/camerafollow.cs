using UnityEngine;
public class camerafollow : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float moveSpeed;
    private void Start()
    {
        moveSpeed = 13.0f;
        offset = transform.position - PlayerPrefab.transform.position;
    }

    void Update()
    {
        Vector3 v = new Vector3(moveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed*Input.GetAxis("Vertical") * Time.deltaTime, 0.0f);
        transform.Translate(v);
    }
}
