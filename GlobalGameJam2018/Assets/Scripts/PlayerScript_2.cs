using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript_2 : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Horizontal");
        float v = verticalSpeed * Input.GetAxis("Vertical");
        transform.position = new Vector3(h, v, 0.0f);
        transform.Translate(0, 0, Time.deltaTime);
    }

}
