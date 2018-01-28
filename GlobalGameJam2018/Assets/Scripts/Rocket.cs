using UnityEngine;

public class Rocket : MonoBehaviour {
    public float rotationSpeed = 100f;
    public float moveSpeed = 5.0f;
    public float smoothSpeed = 20.0f;
    private bool _isRotated = false;
    public float speed = 5f;
    public Vector3 offSet;
    // Use this for initialization
    //Vector3 PlayerPrefabDir = PlayerPrefab.position - transform.position;
    //float angle = Mathf.Atan2(PlayerPrefabDir.y, PlayerPrefabDir.x) * Mathf.Rad2Deg - 90f;
    //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

    private void Awake()
    {
        transform.position = GameState.Instance.Player.transform.position;
        AlignWithPlayer();
    }
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        speed = 5;
        float distanceToPlayer = Vector3.Distance(GameState.Instance.Player.transform.position, transform.position);
        if (distanceToPlayer < 2)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        else
            Destroy(gameObject);
    }
    public void AlignWithPlayer()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// + -135;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != GameState.Instance.Player.name)
            Destroy(gameObject);
        //
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
