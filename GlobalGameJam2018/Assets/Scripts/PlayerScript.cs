using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float moveSpeed;
    public float rotationSpeed = 20f;
    public AudioSource mySource;
    public AudioClip rhinoSwim;
    public GameObject camera;
    public GameObject RocketPrefab;
    public Vector3 offSet;
    public Vector3 b = new Vector3(1f,0f,0f);

    public float moveSpeedBoost = 50;
    private int boostCount = 0;
    private bool isBoostedSpeed = false;   

    public float smoothSpeed = 20.0f;
    Animator animator;
    public bool moving = GameState.Instance.CameraIsMoving;
    
    public void playRhinoSound()
    {
        mySource.PlayOneShot(rhinoSwim);
    }
    void Start () {
        animator= gameObject.GetComponent<Animator>();
        animator.SetBool("moving", false);
        offSet = transform.position - camera.transform.position;
	}

	void Update () {
        if (isBoostedSpeed)
        {
            if (boostCount > 100)
            {
                boostCount = 0;
                isBoostedSpeed = false;
                GameState.Instance.SpeedBoost = 0;
            }
            boostCount++;
        }
        float tempMoveSpeed = moveSpeed + GameState.Instance.SpeedBoost;
        Vector3 v = new Vector3(tempMoveSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime, tempMoveSpeed * -Input.GetAxis("Vertical") * Time.deltaTime, 0.0f);
        transform.Translate(v);

        moving = GameState.Instance.CameraIsMoving;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            playRhinoSound();
            animator.SetBool("moving", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("moving", false);
        }


        FireRocket();
    }
    void FireRocket()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(RocketPrefab);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.ToLower().Contains("mitochondria"))
        {
            isBoostedSpeed = true;
            GameState.Instance.SpeedBoost = moveSpeedBoost;
            Destroy(collision.gameObject);
        }
        //if (collision.gameObject.name == PlayerPrefab.name)
        //isWithinTrigger = true;
    }
}
