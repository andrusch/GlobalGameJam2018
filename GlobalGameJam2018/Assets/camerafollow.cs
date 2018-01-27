using UnityEngine;
public class camerafollow : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - PlayerPrefab.transform.position;
    }

    void LateUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        //transform.LookAt(target);
        transform.position = PlayerPrefab.transform.position + offset;
    }
}
