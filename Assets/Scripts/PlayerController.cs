using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rBody;
    public float speed = 5.0f;
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //use this for physics
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMove, verticalMove, 0);
        rBody.velocity = speed*movement;
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BG1")
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);
            mainCamera.orthographicSize = 5;
        }
        else if (collision.tag == "BG2")
        {
            mainCamera.transform.position = new Vector3(66, 0, mainCamera.transform.position.z);
            mainCamera.orthographicSize = 15;
        }
        else if (collision.tag == "BG3")
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);
            mainCamera.orthographicSize = 28 - this.transform.position.x/6;
        }
    }
}
